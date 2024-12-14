using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Star.Old.Battle.UI;
using UnityEngine.AddressableAssets;
using Cysharp.Threading.Tasks;
using Star.Common;

namespace Star.Old.Battle
{
    public class SkillManager : SingletonMonoBehaviour<SkillManager>
    {
        const string tag = "Skill";
        [SerializeField] List<ActionSkill> actionSkills;
        public List<ActionSkill> ActionSkills { get { return actionSkills; } }
        [SerializeField] SkillUIController skillUIController;
        public async UniTask Initialize()
        {
            actionSkills.Clear();
            await LoadAssets();
            skillUIController.Initialize(actionSkills);
        }

        private async UniTask LoadAssets()
        {
            var handle = Addressables.LoadAssetsAsync<ActionSkill>(tag, null);

            await handle.Task;

            if (handle.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
            {
                foreach (ActionSkill skill in handle.Result)
                {
                    actionSkills.Add(skill);
                }
            }
        }
    }
}