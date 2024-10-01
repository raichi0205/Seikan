using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Effekseer;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine.AddressableAssets;
using Star.Common;

namespace Star.Effect
{
    public class EffectSystem : SingletonMonoBehaviour<EffectSystem>
    {
        List<EffekseerEffectAsset> effectAssets = new List<EffekseerEffectAsset>();

        public async UniTask LoadEffect(string _path)
        {

        }

        public async UniTask LoadEffectAssets()
        {
            var handle = Addressables.LoadAssetsAsync<EffekseerEffectAsset>("Effect", null);
            await handle.Task;
            effectAssets = (List<EffekseerEffectAsset>)handle.Result;
        }

        public EffekseerEffectAsset GetEffectAsset(string _name)
        {
            foreach(EffekseerEffectAsset asset in effectAssets)
            {
                if(asset.name == _name)
                {
                    return asset;
                }
            }
            Debug.LogError($"[Effect] Not Found:{_name}");
            return null;
        }

        public EffekseerEmitter Play(Vector3 _pos, string _effectName, Transform _parent = null, bool _isLoop = false)
        {
            return Play(_pos, GetEffectAsset(_effectName), _parent, _isLoop);
        }

        public EffekseerEmitter Play(Vector3 _pos, EffekseerEffectAsset _effect, Transform _parent = null, bool _isLoop = false)
        {
            GameObject effect = new GameObject();
            EffekseerEmitter effekseerEmitter = effect.AddComponent<EffekseerEmitter>();
            effekseerEmitter.effectAsset = _effect;
            effekseerEmitter.isLooping = _isLoop;
            if(_parent != null)
            {
                effect.transform.SetParent(_parent);
            }
            effect.transform.localPosition = _pos;

            Debug.Log($"[Effect] Start");
            effekseerEmitter.Play();
            return effekseerEmitter;
        }

        public async UniTask EndDelay(EffekseerEmitter _emitter)
        {
            await UniTask.WaitUntil(() => _emitter.IsEnd());
            Debug.Log($"[Effect] End");
        }

        public IEnumerator EndDelayToCoroutine(EffekseerEmitter _emitter)
        {
            yield return EndDelay(_emitter).ToCoroutine();
        }
    }
}