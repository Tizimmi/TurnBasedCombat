using Game.Scripts.BattleSystem.Abilities;
using Game.Scripts.BattleSystem.BattleMembers;
using Game.Scripts.BattleSystem.BattleStateMachine;
using Game.Scripts.BattleSystem.BattleStateMachine.States;
using Game.Scripts.ClientLogic.UI.PlayerInterface;
using Game.Scripts.ReactivePropertyModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Global
{
	public class EntryPoint : MonoBehaviour, ICoroutineRunner
	{
		[SerializeField]
		private UnitDisplayView _enemyView;
		[SerializeField]
		private UnitDisplayView _playerView;
		
		private Player _player;
		private Unit _enemy;
		
		private BattleStateMachine _battleStateMachine;

		private void Awake()
		{
			
			
			_battleStateMachine = new BattleStateMachine(this, _player, _enemy);
			
			_enemyView.Bind(new UnitDisplayViewModel(_enemy));
			_playerView.Bind(new UnitDisplayViewModel(_player));
			
			_battleStateMachine.Enter<PlayerTurnState>();
		}
	}

	public interface ICoroutineRunner
	{
		public Coroutine StartCoroutine(IEnumerator routine);
	}
}