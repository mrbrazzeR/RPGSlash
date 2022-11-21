using System;
using UnityEngine;

namespace Runtime.GamePlay.Character.State
{
    public class StateManager:MonoBehaviour
    {
        [SerializeField]private CharacterState currentState;

        private void Update()
        {
            RunStateMachine();
        }

        private void RunStateMachine()
        {
            CharacterState nextState = currentState?.RunCurrentState();
            if (nextState != null)
            {
                SwitchToNextState(nextState);
            }
        }

        private void SwitchToNextState(CharacterState nextState)
        {
            currentState = nextState;
        }
    }
}