using Game.Scripts.BattleSystem.BattleMembers;
using Game.Scripts.BattleSystem.BattleStateMachine.States;
using Game.Scripts.Global;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.BattleSystem.BattleStateMachine
{
	public class BattleStateMachine
	{
		private IState _currentState;

		private readonly Dictionary<Type, IState> _states;

		public BattleStateMachine(ICoroutineRunner coroutineRunner, Player player, Unit enemy)
		{
			_states = new Dictionary<Type, IState>
			{
				[typeof(PlayerTurnState)] = new PlayerTurnState(this, coroutineRunner, player, enemy),
				[typeof(EnemyTurnState)] = new EnemyTurnState(this, coroutineRunner, enemy, player),
				[typeof(BattleEndState)] = new BattleEndState(this),
			};
		}

		public void Enter<TState>()
			where TState : IState
		{
			_currentState?.Exit();
			var state = _states[typeof(TState)];
			_currentState = state;
			state.Enter();
		}
	}

	public class BattleEndState : IState
	{
		private readonly BattleStateMachine _battleStateMachine;

		public BattleEndState(BattleStateMachine battleStateMachine)
		{
			_battleStateMachine = battleStateMachine;
		}

		public void Enter()
		{
			Debug.LogAssertion("Battle end State");
		}

		public void Exit()
		{
			
		}
	}
}