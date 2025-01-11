using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Star.Battle.UI
{
    public class BattleFooter : MonoBehaviour
    {
        [SerializeField] CharacterInfo characterInfo;
        public CharacterInfo CharacterInfo { get { return characterInfo; } }
        [SerializeField] OtherInfo otherInfo;
        public OtherInfo OtherInfo { get { return otherInfo; } }

        public void Initialize()
        {
            characterInfo.Initialize();
        }
    }
}