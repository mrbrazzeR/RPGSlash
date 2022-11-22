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
            
            SetAnimator();
            MovingToTown();
            if (comeToTown)
            {
                comeToTown = !comeToTown;
                parentObject.transform.Rotate(0,180f,0);
                _rotated = !_rotated;
                return idleState;
            }
            return this;
        }

        protected virtual void SetAnimator()
        {
            animator.SetBool(Walk, true);
            animator.SetBool(Fish, false);
        }

        private void MovingToTown()
        {
            var go = GameObject.FindGameObjectWithTag("town");
            position = go.transform.position;
            if (!_rotated)
            {
                parentObject.transform.Rotate(0,180f,0);
                _rotated = true;
            }
            parentObject.transform.position = Vector3.MoveTowards(transform.position, position, 0.01f);
            if (transform.position == go.transform.position)
            {
                comeToTown = true;
            }
            
           
        }
    }
}