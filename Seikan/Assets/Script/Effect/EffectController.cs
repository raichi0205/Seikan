using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Cysharp.Threading.Tasks;
using UniRx;
using UniRx.Triggers;
using UnityEngine.Events;

namespace Star.Effect
{
    public class EffectController : MonoBehaviour
    {
        [SerializeField] Animator animator;
        [SerializeField] Image image;
        [SerializeField] EffectSound effectSound;
        UnityEvent onAnimationEnd = new UnityEvent();
        const string PlayFlagName = "Play";

        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Initialize()
        {
            image.enabled = false;
        }

        /// <summary>
        /// アニメーションコントローラーの設定
        /// </summary>
        /// <param name="_animController">上書きするコントローラー</param>
        public void SetAnimatorController(RuntimeAnimatorController _animController)
        {
            animator.runtimeAnimatorController = _animController;
            
            ObservableStateMachineTrigger trigger = animator.GetBehaviour<ObservableStateMachineTrigger>();       // ステート取得
            if (trigger != null)
            {
                trigger
                    .OnStateEnterAsObservable()
                    .Where(x => x.StateInfo.IsName("Effect"))
                    .Subscribe(x =>
                    {
                        Debug.Log("[Anim] 開始");
                        image.enabled = true;
                    }).AddTo(this);

                trigger
                    .OnStateExitAsObservable()
                    .Where(x => x.StateInfo.IsName("Effect"))
                    .Subscribe(x =>
                    {
                        Debug.Log("[Anim] 終了");
                        onAnimationEnd.Invoke();
                        animator.SetBool(PlayFlagName, false);
                        effectSound.Clear();
                    }).AddTo(this);
            }
            else 
            {
                Debug.LogError("[Anim] ステートの取得に失敗。\nコントローラーが適切に設定されていますか");
                if(animator.runtimeAnimatorController == null)
                {
                    Debug.LogError("[Anim] コントローラーが適切に設定されていますか？");
                }
            }
        }

        /// <summary>
        /// 再生処理
        /// </summary>
        /// <param name="_callBack">終了時の処理</param>
        public void Play(UnityAction _callBack = null)
        {
            animator.SetBool(PlayFlagName, true);
            if(_callBack != null)
            {
                onAnimationEnd.AddListener(_callBack);
            }
        }

        /// <summary>
        /// アニメーション終了検知
        /// </summary>
        /// <returns></returns>
        public async UniTask EndDelay()
        {
            await UniTask.WaitUntil(() => !animator.GetBool(PlayFlagName));
            onAnimationEnd.RemoveAllListeners();        // コールバック削除
            image.enabled = false;
        }
    }
}