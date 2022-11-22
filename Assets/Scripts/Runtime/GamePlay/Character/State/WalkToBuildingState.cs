using UnityEngine;

namespace Runtime.GamePlay.Character.State
{
    public class WalkToBuildingState:CharacterState
    {
        public HarvestState harvestState;
        public bool comeToBuilding;
        public GameObject parentObject;
        [SerializeField] private Animator animator;
        private static readonly int Fish = Animator.StringToHash("harvest");
        private static readonly int Walk = Animator.StringToHash("walk");
        public override CharacterState RunCurrentState()
        {
            SetAnimator();
           MovingToBuilding();
            if (comeToBuilding)
            {
                comeToBuilding = !comeToBuilding;
                
                return harvestState;
            }
            return this;
        }

        protected virtual void SetAnimator()
        {
            animator.SetBool(Walk, true);
            animator.SetBool(Fish, false);
        }

        private void MovingToBuilding()
        {
            parentObject.transform.position = Vector3.MoveTowards(transform.position, position, 0.01f);
            if (transform.position == position) comeToBuilding = true;
        }
    }
}