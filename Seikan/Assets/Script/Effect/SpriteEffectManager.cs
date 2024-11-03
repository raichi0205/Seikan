using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using Star.Common;

namespace Star.Effect
{
    public class SpriteEffectManager : SingletonMonoBehaviour<SpriteEffectManager>
    {
        const string label = "Effect";

        public enum AnimType
        {
            IMAGE,
            SPRITE,
        }

        Dictionary<string, SpriteAnimation> animations = new Dictionary<string, SpriteAnimation>();

        /// <summary>
        /// エフェクトの初期化処理 
        /// </summary>
        /// <param name="_animName"></param>
        /// <param name="_effectController"></param>
        public void SetEffect(string _animName, EffectController _effectController)
        {
            if (animations.ContainsKey(_animName)) 
            {
                _effectController.SetAnimatorController(animations[_animName].AnimController);
            }
        }

        /// <summary>
        /// 読込処理
        /// </summary>
        /// <param name="_animName"></param>
        /// <returns></returns>
        public async UniTask LoadEffect(string _animName)
        {
            var handle = Addressables.LoadAssetAsync<SpriteAnimation>(_animName);
            await handle.Task;
            if(handle.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
            {
                animations.Add(handle.Result.name, handle.Result);
            }
            else if(handle.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Failed)
            {
                Debug.LogError($"[AssetLoad] Failed:{_animName}");
            }
        }

        /// <summary>
        /// 読込処理
        /// </summary>
        /// <returns></returns>
        public async UniTask LoadEffectAssets()
        {
            var handle = Addressables.LoadAssetsAsync<SpriteAnimation>(label, null);
            await handle.Task;
            if(handle.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
            {
                foreach(var spriteAnim in handle.Result)
                {
                    animations.Add(spriteAnim.name, spriteAnim);
                }
            }
            else if(handle.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Failed)
            {
                Debug.LogError($"[AssetLoad] Failed:{label}");
            }
        }
    }
}