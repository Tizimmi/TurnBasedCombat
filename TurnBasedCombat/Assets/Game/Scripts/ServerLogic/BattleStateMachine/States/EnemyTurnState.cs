using Game.Scripts.BattleSystem.BattleMembers;
using Game.Scripts.Global;
using UnityEngine;

namespace Game.Scripts.ServerLogic.BattleStateMachine.States
{
	public class EnemyTurnState : IState
	{
		private readonly BattleControllerStateMachine _battleControllerStateMachine;
		private readonly ICoroutineRunner _coroutineRunner;
		private readonly Unit _enemy;
		private readonly EventDispatcher _eventDispatcher;

		public EnemyTurnState(Unit enemy, EventDispatcher eventDispatcher)
		{
			_enemy = enemy;
			_eventDispatcher = eventDispatcher;
		}

		public void Enter()
		{
			if (_enemy.CurrentHealth.Value <= 0)
			{
				_eventDispatcher.DispatchEvent(EventType.GameOver, "Player");
			}
			_enemy.UseRandomAbility();
		}

		public void Exit()
		{
			Debug.Log($"Enemy ended it's turn with {_enemy.CurrentHealth.Value}");
		}
	}
}