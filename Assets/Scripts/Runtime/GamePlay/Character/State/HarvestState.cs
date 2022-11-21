using UnityEngine;

namespace Runtime.GamePlay.Character.State
{
    public class HarvestState:CharacterState
    {
        public WalkToTownState walkToTownState;
        public bool harvestDone;
        [SerializeField] private Animator animator;
        private static readonly int Fish = Animator.StringToHash("harvest");
        private static readonly int Walk = Animator.StringToHash("walk");
        public override CharacterState RunCurrentState()
        {
            SetAnimator();
            Invoke(nameof(ChangeState),2f);
            if (harvestDone)
            {
                harvestDone = !harvestDone;
                CancelInvoke();
                return walkToTownState;
            }

            return this;
        }

        public override void SetAnimator()
        {
            animator.SetBool(Walk, false);
            animator.SetBool(Fish, true);
        }

        public void ChangeState()
        {
            harvestDone = !harvestDone;
        }
    }
}