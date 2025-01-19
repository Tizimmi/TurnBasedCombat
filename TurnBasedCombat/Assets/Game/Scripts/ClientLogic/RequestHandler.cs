using Game.Scripts.ServerLogic;
using Game.Scripts.ServerLogic.Abilities;
using Game.Scripts.ServerLogic.BattleStateMachine;
using Game.Scripts.ServerLogic.BattleStateMachine.States;

namespace Game.Scripts.ClientLogic
{
	public class RequestHandler
	{
		private readonly BattleControllerStateMachine _battleController;

		public RequestHandler(BusinessLogic businessLogic)
		{
			_battleController = businessLogic._battleControllerStateMachine;
		}

		public void HandlePlayerAction(AbilityType attackType)
		{
			_battleController.Enter<PlayerTurnState, AbilityType>(attackType);
		}

		public void HandleEnemyAction()
		{
			_battleController.Enter<EnemyTurnState>();
		}
	}
}