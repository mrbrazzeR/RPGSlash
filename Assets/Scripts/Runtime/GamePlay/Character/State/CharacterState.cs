namespace Runtime.GamePlay.Character.State
{
    public interface ICharacterState
    {
        ICharacterState RunCurrentState();
    }
}