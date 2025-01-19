using Game.Scripts.ClientLogic;
using Game.Scripts.ServerLogic.Abilities;

namespace Game.Scripts.Global
{
	public class BattleUI
	{
		private readonly RequestHandler _requestHandler;
		private readonly ICoroutineRunner _coroutineRunner; 

		public BattleUI(RequestHandler requestHandler, ICoroutineRunner coroutineRunner)
		{
			_requestHandler = requestHandler;
			_coroutineRunner = coroutineRunner;
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