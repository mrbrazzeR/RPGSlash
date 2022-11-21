using UnityEngine;

namespace Runtime.GamePlay.Character.State
{
    public abstract class CharacterState:MonoBehaviour
    {
        public static Vector3 Position;
        public abstract CharacterState RunCurrentState();
        public abstract void SetAnimator();
    }
}