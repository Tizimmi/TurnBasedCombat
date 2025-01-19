namespace Game.Scripts.ServerLogic.BattleStateMachine.States
{
	public interface IState : IExitableState
	{
		void Enter();
	}

	public interface IPayloadedState<TPayload> : IExitableState
	{
		void Enter(TPayload payload);
	}
}