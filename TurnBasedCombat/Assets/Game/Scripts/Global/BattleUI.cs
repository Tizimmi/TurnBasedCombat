using Game.Scripts.ClientLogic;
using Game.Scripts.ServerLogic.Abilities;

namespace Game.Scripts.Global
{
	public class BattleUI
	{
		private readonly RequestHandler _requestHandler;

		public BattleUI(RequestHandler requestHandler)
		{
			_requestHandler = requestHandler;
		}

		public void PlayerTryAttack()
		{
			_requestHandler.HandlePlayerAction(AbilityType.DefaultAttack);
		}

		public void EnemyTryAttack()
		{
			_requestHandler.HandleEnemyAction();
		}
	}
}