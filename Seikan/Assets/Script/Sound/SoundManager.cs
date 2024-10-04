using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Audio;
using System.Collections.Generic;
using Star.Common;
using Star.Editor;
using Cysharp.Threading.Tasks;

namespace Star.Sound
{
    public class SoundManager : SingletonMonoBehaviour<SoundManager>
    {
        public enum MixerGroup
        {
            None = -1,
            Music = 0,
            SE,
            Voice,
            Num
        }

        [SerializeField] AudioMixer mixer;
        [SerializeField, NamedArray(typeof(MixerGroup))] AudioMixerGroup[] mixerGroups = new AudioMixerGroup[(int)MixerGroup.Num];
        Dictionary<MixerGroup, Dictionary<string, AudioClip>> audioClips = new Dictionary<MixerGroup, Dictionary<string, AudioClip>>();

        public void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            DontDestroyOnLoad(this);        // ToDo: 管理シーンに渡すようにする
            audioClips.Add(MixerGroup.Music, new Dictionary<string, AudioClip>());
            audioClips.Add(MixerGroup.SE, new Dictionary<string, AudioClip>());
            audioClips.Add(MixerGroup.Voice, new Dictionary<string, AudioClip>());
        }

        public AudioSource Play(MixerGroup _group, string _name, bool _isLoop = false, AudioSource _audioSource = null, GameObject _obj = null)
        {
            AudioSource source = _audioSource;
            GameObject obj = _obj;
            if(source == null)
            {
                if(obj == null)
                {
                    obj = this.gameObject;
                }
                source = obj.AddComponent<AudioSource>();
            }
            if (!audioClips[_group].ContainsKey(_name))
            {
                Debug.LogError($"[Sound] Not Found:{_name}");
                return null;
            }
            source.outputAudioMixerGroup = mixerGroups[(int)_group];
            source.clip = audioClips[_group][_name];
            source.loop = _isLoop;
            source.Play();
            return source;
        }

        public async UniTask<bool> LoadAudio(MixerGroup _group, string _path)
        {
            var handle = Addressables.LoadAssetAsync<AudioClip>(_path);
            await handle.Task;
            if(handle.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
            {
                audioClips[_group].Add(handle.Result.name, handle.Result);
            }
            else
            {
                Debug.LogError($"[Sound] Load Error:{_path}");
                return false;
            }
            return true;
        }

        public async UniTask<bool> LoadAudios(MixerGroup _group, string _label)
        {
            var handle = Addressables.LoadAssetsAsync<AudioClip>(_label, null);
            await handle.Task;
            if(handle.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
            {
                foreach(var clip in handle.Result)
                {
                    audioClips[_group].Add(clip.name, clip);
                }
            }
            else
            {
                Debug.LogError($"[Sound] Load Error:{_label}");
                return false;
            }
            return true;
        }

        public void UnLoadAudio(MixerGroup _group, string _name)
        {
            Addressables.Release(audioClips[_group][_name]);
        }

        public void UnLoadAudios(MixerGroup _group)
        {
            Addressables.Release(audioClips[_group]);
        }
    }
}