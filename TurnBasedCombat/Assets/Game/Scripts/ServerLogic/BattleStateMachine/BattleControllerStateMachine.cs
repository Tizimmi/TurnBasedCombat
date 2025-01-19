using Game.Scripts.BattleSystem.BattleMembers;
using Game.Scripts.ServerLogic.Abilities;
using Game.Scripts.ServerLogic.BattleStateMachine.States;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.ServerLogic.BattleStateMachine
{
	public class BattleControllerStateMachine
	{
		private IExitableState _currentState;

		private readonly Dictionary<Type, IExitableState> _states;
		
		private readonly Unit _player;
		private readonly Unit _enemy;

		public BattleControllerStateMachine(EventDispatcher eventDispatcher)
		{
			_player = new Unit(100);
			_enemy = new Unit(100);
			
			_player.Abilities.Add(new DefaultAttack(_enemy, 10, AbilityType.DefaultAttack));
			_enemy.Abilities.Add(new DefaultAttack(_player, 10, AbilityType.DefaultAttack));
			
			_states = new Dictionary<Type, IExitableState>
			{
				[typeof(PlayerTurnState)] = new PlayerTurnState(eventDispatcher, _player),
				[typeof(EnemyTurnState)] = new EnemyTurnState(_enemy, eventDispatcher),
				[typeof(EndTurnState)] = new EndTurnState(),
				[typeof(BattleEndState)] = new BattleEndState(this),
			};
		}

		public void Enter<TState>()
			where TState : class, IState
		{
			IState state = ChangeState<TState>();
			state.Enter();
		}

		public void Enter<TState, TPayload>(TPayload payload)
			where TState : class, IPayloadedState<TPayload>
		{
			var state = ChangeState<TState>();
			state.Enter(payload);
		}

		private TState ChangeState<TState>()
			where TState : class, IExitableState
		{
			_currentState?.Exit();

			var state = GetState<TState>();
			_currentState = state;

			return state;
		}

		private TState GetState<TState>()
			where TState : class, IExitableState
		{
			return _states[typeof(TState)] as TState;
		}
	}

	public class BattleEndState : IState
	{
		private readonly BattleControllerStateMachine _battleControllerStateMachine;

		public BattleEndState(BattleControllerStateMachine battleControllerStateMachine)
		{
			_battleControllerStateMachine = battleControllerStateMachine;
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