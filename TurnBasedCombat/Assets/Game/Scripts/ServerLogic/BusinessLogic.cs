namespace Game.Scripts.ServerLogic
{
	public class BusinessLogic
	{
		public readonly BattleStateMachine.BattleControllerStateMachine _battleControllerStateMachine;

		public BusinessLogic(EventDispatcher eventDispatcher)
		{
			_battleControllerStateMachine = new BattleStateMachine.BattleControllerStateMachine(eventDispatcher);
		}

		public void StartTurn()
		{
			
		}
	}
}