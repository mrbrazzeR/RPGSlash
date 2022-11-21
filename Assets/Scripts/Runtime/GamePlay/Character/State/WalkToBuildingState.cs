namespace Runtime.GamePlay.Character.State
{
    public class WalkState:CharacterState
    {
        public HarvestState harvestState;
        public bool comeToBuilding;
        public override CharacterState RunCurrentState()
        {
            if (comeToBuilding)
            {
                return harvestState;
            }
            return this;
        }
    }
}