namespace Assets.Project.CodeBase.SharkEnemy.StateMashine.Interface
{
    public interface ISwitchState
    {
        void SwitchState<State>() where State : IState;
    }
}
