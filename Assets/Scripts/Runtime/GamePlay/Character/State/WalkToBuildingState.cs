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
            parentObject.transform.position = Vector3.MoveTowards(transform.position, Position, 0.01f);
            if (transform.position == Position) comeToBuilding = true;
            if (comeToBuilding)
            {
                comeToBuilding = !comeToBuilding;
                
                return harvestState;
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