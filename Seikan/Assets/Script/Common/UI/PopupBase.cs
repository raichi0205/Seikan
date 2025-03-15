using UnityEngine;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace Star.Common.UI
{
    public class PopupBase : MonoBehaviour
    {
        [SerializeField] protected float duration = 0.5f;

        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Initialize()
        {
            gameObject.transform.localScale = Vector3.zero;
        }

        /// <summary>
        /// ポップアップを開く
        /// </summary>
        /// <returns></returns>
        public async UniTask Open()
        {
            await gameObject.transform.DOScale(1, duration).AsyncWaitForCompletion();
        }

        public async UniTask Close()
        {
            await gameObject.transform.DOScale(0, duration / 2).AsyncWaitForCompletion();
            Destroy(gameObject);
        }
    }
}