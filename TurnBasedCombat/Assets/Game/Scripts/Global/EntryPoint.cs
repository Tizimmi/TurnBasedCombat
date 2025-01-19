using Game.Scripts.ClientLogic;
using Game.Scripts.ServerLogic;
using Game.Scripts.ServerLogic.Abilities;
using System.Collections;
using UnityEngine;
using EventType = Game.Scripts.ServerLogic.EventType;

namespace Game.Scripts.Global
{
	public class EntryPoint : MonoBehaviour, ICoroutineRunner
	{
		private void Awake()
		{
			EventDispatcher eventDispatcher = new EventDispatcher();
			BusinessLogic businessLogic = new BusinessLogic(eventDispatcher);
			RequestHandler requestHandler = new RequestHandler(businessLogic);
			BattleUI battleUI = new BattleUI(requestHandler, this);
			
			eventDispatcher.AddListener<IAbility>(EventType.PlayerAction, Listener);
			
			battleUI.PlayerTryAttack();
		}

		private void Listener(IAbility ability)
		{
			Debug.Log(ability.GetType().ToString());
		}
	}
	

	public interface ICoroutineRunner
	{
		public Coroutine StartCoroutine(IEnumerator routine);
	}
}