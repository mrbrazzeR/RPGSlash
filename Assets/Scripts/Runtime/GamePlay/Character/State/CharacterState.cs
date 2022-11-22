using UnityEngine;

namespace Runtime.GamePlay.Character.State
{
    public abstract class CharacterState:MonoBehaviour
    {
        public Vector3 position;
        public abstract CharacterState RunCurrentState();
    }
}