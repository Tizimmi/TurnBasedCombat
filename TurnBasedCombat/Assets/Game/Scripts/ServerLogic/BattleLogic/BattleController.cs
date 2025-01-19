using Game.Scripts.BattleSystem.BattleMembers;
using Game.Scripts.ServerLogic.Abilities;

namespace Game.Scripts.ServerLogic.BattleLogic
{
	public class BattleController
	{
		private Unit _enemy;
		private Unit _player;

		private readonly EventDispatcher _eventDispatcher;

		private bool _isPlayerTurn = true;

		public BattleController(EventDispatcher dispatcher)
		{
			_eventDispatcher = dispatcher;

			_player = new Unit(100);
			_enemy = new Unit(100);

			_player.Abilities.Add(new DefaultAttack(_enemy, 10, AbilityType.DefaultAttack));
			_enemy.Abilities.Add(new DefaultAttack(_player, 10, AbilityType.DefaultAttack));
		}

		public void ProcessPlayerAction(AbilityType abilityType)
		{
			if (!_isPlayerTurn)
				return;

			var ability = _player.UseAbility(abilityType);
			_eventDispatcher.DispatchEvent(EventType.PlayerAction, ability);

			// CheckForWinner();
			SwitchTurn();
		}

		public void ProcessEnemyAction()
		{
			if (_isPlayerTurn)
				return;

			var ability = _enemy.UseRandomAbility();
			_eventDispatcher.DispatchEvent(EventType.EnemyAction, ability);

			// CheckForWinner();
			SwitchTurn();
		}

		private void SwitchTurn()
		{
			_isPlayerTurn = !_isPlayerTurn;
		}

		// private void CheckForWinner()
		// {
		// 	if (_player.CurrentHealth.Value <= 0)
		// 		_eventDispatcher.DispatchEvent("GameOver", "Enemy");
		//
		// 	else if (_enemy.CurrentHealth.Value <= 0)
		// 		_eventDispatcher.DispatchEvent("GameOver", "Player");
		// }
	}
}