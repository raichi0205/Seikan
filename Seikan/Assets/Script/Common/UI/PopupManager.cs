using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Star.Common.UI
{
    public class PopupManager : SingletonMonoBehaviour<PopupManager>
    {
        [SerializeField] List<PopupBase> popupList = new List<PopupBase>();

        public async UniTask<PopupBase> GetPopup(string _path)
        {
            PopupBase popup = (await LoadPopup(_path)).GetComponent<PopupBase>();
            if (popup != null)
            {
                PopupBase obj = Instantiate(popup);
                obj.transform.SetParent(gameObject.transform, false);
                return obj;
            }
            else
            {
                Debug.LogError($"[Popup] 読み込みに失敗しました:{_path}");
            }
            return null;
        }

        private async UniTask<GameObject> LoadPopup(string _path)
        {
            return await Addressables.LoadAssetAsync<GameObject>(_path);
        }
    }
}