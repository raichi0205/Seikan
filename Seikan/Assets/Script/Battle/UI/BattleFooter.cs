using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Star.Battle.UI
{
    public class BattleFooter : MonoBehaviour
    {
        [SerializeField] CharacterInfo characterInfo;
        public CharacterInfo CharacterInfo { get { return characterInfo; } }

        public void Initialize()
        {
            characterInfo.Initialize();
        }
    }
}