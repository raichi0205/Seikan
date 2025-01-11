using UnityEngine;
using System.Collections;
using Star.Common;
using Star.Character;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Star.Core
{
    public class GameManager : Singleton<GameManager>
    {
        const string actorPath = "actor";
        ActorData actorData = new ActorData();
        public ActorData ActorData { get { return actorData; } }

        public GameManager()
        {
            
        }

        public async UniTask Load()
        {
            var handle = Addressables.LoadAssetAsync<ActorData>(actorPath);
            await handle.Task;
            actorData.Clone(handle.Result);
            Debug.Log($"[Load]actor:{handle.Result.CharaName}");

            await Star.Battle.SkillManager.Instance.Initialize();
        }
    }
}