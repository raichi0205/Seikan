using UnityEngine;

namespace Star.Effect
{
    [CreateAssetMenu(fileName = "SpriteAnimData",menuName = "ScriptableObjects/Effect/SpriteAnimation")]
    public class SpriteAnimation : ScriptableObject
    {
        public RuntimeAnimatorController AnimController;
        public AnimationClip AnimationClip;
        public Texture2D Texture;
    }
}