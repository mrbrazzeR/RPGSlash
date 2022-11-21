using UnityEngine;

namespace Runtime.GamePlay.Character.State
{
    public class WalkToTownState:CharacterState
    { 
        public bool comeToTown;
        public IdleState idleState;
        public GameObject parentObject;
        private bool _rotated;
        [SerializeField] private Animator animator;
        private static readonly int Fish = Animator.StringToHash("harvest");
        private static readonly int Walk = Animator.StringToHash("walk");
        public override CharacterState RunCurrentState()
        {
            var go = GameObject.FindGameObjectWithTag("town");
            SetAnimator();
            Position = go.transform.position;
            if (!_rotated)
            {
                parentObject.transform.Rotate(0,180f,0);
                _rotated = true;
            }
            parentObject.transform.position = Vector3.MoveTowards(transform.position, Position, 0.01f);
            if (transform.position == go.transform.position)
            {
                comeToTown = true;
            }
            
            if (comeToTown)
            {
                comeToTown = !comeToTown;
                parentObject.transform.Rotate(0,180f,0);
                _rotated = !_rotated;
                return idleState;
            }
            return this;
        }

        public override void SetAnimator()
        {
            animator.SetBool(Walk, true);
            animator.SetBool(Fish, false);
        }
    }
}