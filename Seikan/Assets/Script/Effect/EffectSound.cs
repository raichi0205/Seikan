using UnityEngine;
using System.Collections.Generic;
using Star.Sound;

namespace Star.Effect
{
    public class EffectSound : MonoBehaviour
    {
        List<AudioSource> currentAudioSources = new List<AudioSource>();
        /// <summary>
        /// エフェクトのサウンド再生
        /// アニメーションクリップ側から関数名で参照している
        /// </summary>
        /// <param name="_soundName"></param>
        public void PlaySE(string _soundName)
        {
            currentAudioSources.Add(SoundManager.Instance.Play(SoundManager.MixerGroup.SE, _soundName, _obj: this.gameObject));
        }

        /// <summary>
        /// SEで使ったソースの解放
        /// </summary>
        public void Clear()
        {
            foreach(AudioSource source in currentAudioSources)
            {
                Destroy(source);
            }
            currentAudioSources.Clear();
        }
    }
}