using UnityEngine;

namespace Runtime.GamePlay.Character.State
{
    public class IdleState:CharacterState
    {
        public bool hasNearest;
        public WalkToBuildingState walkToBuildingState;
        [SerializeField] private Animator animator;
        private static readonly int Fish = Animator.StringToHash("harvest");
        private static readonly int Walk = Animator.StringToHash("walk");
        public override CharacterState RunCurrentState()
        {
            Invoke(nameof(GetPosition),2f);
            if (hasNearest)
            {
                hasNearest = !hasNearest;
                CancelInvoke();
                return walkToBuildingState;
            }
            return this;
        }

        public override void SetAnimator()
        {
            animator.SetBool(Walk, false);
            animator.SetBool(Fish, false);
        }

        public void GetPosition()
        {
            SetAnimator();
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("fish_hut");
            GameObject closest = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (GameObject go in gos)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                    hasNearest = true;
                }
            }

            if (closest != null) Position = closest.transform.position;
        }
    }
}