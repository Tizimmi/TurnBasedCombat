using Game.Scripts.BattleSystem.BattleMembers;
using Game.Scripts.Global;
using System.Collections;
using UnityEngine;

namespace Game.Scripts.BattleSystem.BattleStateMachine.States
{
	public class EnemyTurnState : IState
	{
		private readonly BattleStateMachine _battleStateMachine;
		private readonly ICoroutineRunner _coroutineRunner;
		private readonly Unit _unit;
		private readonly Unit _target;

		public EnemyTurnState(
			BattleStateMachine battleStateMachine,
			ICoroutineRunner coroutineRunner,
			Unit unit,
			Unit target)
		{
			_battleStateMachine = battleStateMachine;
			_coroutineRunner = coroutineRunner;
			_unit = unit;
			_target = target;
		}

		public void Enter()
		{
			if (_unit.CurrentHealth.Value <= 0 || _target.CurrentHealth.Value <= 0)
			{
				_battleStateMachine.Enter<BattleEndState>();
			}
			else
			{
				_unit.UseRandomAbility(_target);
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
			
			_battleStateMachine.Enter<PlayerTurnState>();
		}

		public void Exit()
		{
			Debug.Log("Enemy ended it's turn");
		}
	}
}