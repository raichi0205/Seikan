using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using UnityEngine.Events;

namespace Star.Common.UI
{
    public class CommonButton : Button
    {
        [SerializeField] TextMeshProUGUI text;
        public TextMeshProUGUI Text { get { return text; } }

        //長押し時の挙動対応
        [SerializeField] public bool isLoop = false;         //長押しを許可するか
        [SerializeField] public float wait = 0.0f;           //処理間隔
        public UnityEvent onLongPress = new UnityEvent();
        private float pressingSeconds = 0.0f;       //押されてからの時間
        private bool isPressing = false;            //押し続けられているか

        [SerializeField] public bool forcedSave = false;  //強制的にDirtyフラグを立てる

        protected override void Start()
        {
            Init();
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Init()
        {
            //テキストのコンポーネント取得
            if (text == null)
            {
                text = GetComponentInChildren<TextMeshProUGUI>();       //どういうわけか外れるケースがあるのでごり押し対応
            }
        }

        /// <summary>
        /// Update文
        /// </summary>
        private void Update()
        {
            Pressing();
        }

        /// <summary>
        /// 長押し挙動用のループ処理
        /// </summary>
        private void Pressing()
        {
            if (isLoop && isPressing)
            {
                pressingSeconds += Time.deltaTime;      //秒計算
                if (pressingSeconds >= wait)
                {
                    onLongPress.Invoke();
                    onClick.Invoke();
                    pressingSeconds = 0.0f;
                }
            }
        }

        /// <summary>
        /// 入力状態をとるコールバック
        /// </summary>
        /// <param name="eventData"></param>
        public override void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            isPressing = true;
        }

        /// <summary>
        /// ボタンから離した時に取るコールバック
        /// </summary>
        /// <param name="eventData"></param>
        public override void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            pressingSeconds = 0.0f;
            isPressing = false;
        }

#if UNITY_EDITOR

        /// <summary>
        /// エディタ拡張
        /// </summary>
        [CustomEditor(typeof(CommonButton))]
        public class CommonButtonEditor : UnityEditor.UI.ButtonEditor
        {
            /// <summary>
            /// inspectorの表記
            /// </summary>
            public override void OnInspectorGUI()
            {
                base.OnInspectorGUI();
                serializedObject.Update();

                CommonButton component = (CommonButton)target;

                PropertyField(nameof(component.text), "ボタンのテキスト");
                PropertyField(nameof(component.isLoop), "isLoop");
                PropertyField(nameof(component.wait), "wait");

                component.forcedSave = (bool)EditorGUILayout.Toggle("強制セーブ", component.forcedSave);
                if (component.forcedSave)
                {
                    EditorUtility.SetDirty(target);
                    component.forcedSave = false;         //フラグ立てたら一旦戻す
                }

                //プロパティの変更を適用
                serializedObject.ApplyModifiedProperties();         //Memo: これSerializeされてないとうまく動かないしserializeObjectを通した値の変更でないとダメ
            }

            private void PropertyField(string _property, string _label)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty(_property), new GUIContent(_label));
            }
        }

        [MenuItem("GameObject/Common/UI/CommonButton", priority = 2)]
        public static void Commonbutton()
        {
            var obj = new GameObject();
            obj.transform.SetParent(Selection.activeGameObject.transform, false);
            var image = obj.AddComponent<Image>();
            var button = obj.AddComponent<CommonButton>();
            button.image = image;
        }
#endif
    }
}