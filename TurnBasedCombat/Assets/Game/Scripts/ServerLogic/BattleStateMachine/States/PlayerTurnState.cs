using Game.Scripts.BattleSystem.BattleMembers;
using Game.Scripts.Global;
using Game.Scripts.ServerLogic.Abilities;
using System.Collections;
using UnityEngine;

namespace Game.Scripts.ServerLogic.BattleStateMachine.States
{
	public class PlayerTurnState : IPayloadedState<AbilityType>
	{
		private readonly EventDispatcher _eventDispatcher;
		private readonly ICoroutineRunner _coroutineRunner;
		private readonly Unit _player;
		private readonly Unit _target;

		public PlayerTurnState(EventDispatcher eventDispatcher,
			Unit player)
		{
			_eventDispatcher = eventDispatcher;
			_player = player;
		}

		public void Enter(AbilityType payload)
		{
			if (_player.CurrentHealth.Value <= 0)
			{
				_eventDispatcher.DispatchEvent(EventType.GameOver, "Enemy");
				return;
			}
			
			_player.UseAbility(payload);
		}

		public void Exit()
		{
			Debug.Log($"Player ended his turn with {_player.CurrentHealth.Value}");
		}
	}
}