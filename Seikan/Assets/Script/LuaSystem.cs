using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using XLua;
using Star.Common;

namespace Star.Lua
{
    public class LuaSystem : SingletonMonoBehaviour<LuaSystem>
    {
        private LuaEnv luaEnv;
        private List<TextAsset> loadScriptFiles = new List<TextAsset>();

        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            DontDestroyOnLoad(gameObject);
            luaEnv = new LuaEnv();
            luaEnv.AddLoader(CustomLoader);     // カスタムローダをセット
            Coroutine InvokeStartCoroutine(IEnumerator routine) => StartCoroutine(routine);
            void InvokeStopCoroutine(Coroutine coroutine) => StopCoroutine(coroutine);
            luaEnv.Global.Set("csStartCoroutine", (Func<IEnumerator, Coroutine>)InvokeStartCoroutine);      //コルーチン開始をグローバルで定義
            luaEnv.Global.Set("csStopCoroutine", (Action<Coroutine>)InvokeStopCoroutine);                   //コルーチン停止をグローバルで定義
        }

        public void StarLua(string _path)
        {
            Debug.Log($"[Lua] Start:{_path}");
            luaEnv.DoString($"require \"{_path}\"");
        }

        private byte[] CustomLoader(ref string _filePath)
        {
            AsyncLoaderToBytes(_filePath, (value)=> { luaEnv.DoString(value); });
            var encoding = Encoding.GetEncoding("UTF-8");
            return encoding.GetBytes($"CS.UnityEngine.Debug.Log(\"[Lua] Load:{_filePath}\")");
        }

        private async Task<byte[]> AsyncLoaderToBytes(string _filePath, Action<byte[]> onCompleate = null)
        {
            var loaderHandle = Addressables.LoadAssetAsync<TextAsset>(_filePath);
            await loaderHandle.Task;

            if(loaderHandle.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
            {
                Debug.Log($"[AAS] Load Success:{_filePath}");
                onCompleate.Invoke(loaderHandle.Result.bytes);
                return loaderHandle.Result.bytes;
            }
            else
            {
                Debug.LogError($"[AAS] Load Failed:{_filePath}");
                return null;
            }
        }

        private void Update()
        {
            luaEnv.Tick();
        }

        private void OnDestroy()
        {
            luaEnv.Dispose();
        }
    }
}