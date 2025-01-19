using Game.Scripts.BattleSystem.Abilities;
using Game.Scripts.BattleSystem.BattleMembers;
using Game.Scripts.Global;
using System.Collections;
using UnityEngine;

namespace Game.Scripts.BattleSystem.BattleStateMachine.States
{
	public class PlayerTurnState : IState
	{
		private readonly BattleStateMachine _battleStateMachine;
		private readonly ICoroutineRunner _coroutineRunner;
		private readonly Player _player;
		private readonly Unit _target;

		public PlayerTurnState(
			BattleStateMachine battleStateMachine,
			ICoroutineRunner coroutineRunner,
			Player player,
			Unit target)
		{
			_battleStateMachine = battleStateMachine;
			_coroutineRunner = coroutineRunner;
			_player = player;
			_target = target;
		}

		public void Enter()
		{
			if (_player.CurrentHealth.Value <= 0 || _target.CurrentHealth.Value <= 0)
			{
				_battleStateMachine.Enter<BattleEndState>();
			}
			else
			{
				_player.UseRandomAbility(_target);
				SwitchTurn();
			}
		}

		private void SwitchTurn()
		{
			_coroutineRunner.StartCoroutine(Timer(1));
		}

		private IEnumerator Timer(int seconds)
		{
			yield return new WaitForSeconds(seconds);
			
			_battleStateMachine.Enter<EnemyTurnState>();
		}

		public void Exit()
		{
			Debug.Log("Player ended his turn");
		}
	}
}