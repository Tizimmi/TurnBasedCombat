using System;
using System.Collections.Generic;

namespace Game.Scripts.ServerLogic
{
	public class EventDispatcher
	{
		private readonly Dictionary<EventType, Action<object>> _eventListeners = new();

		public void AddListener<T>(EventType eventName, Action<T> listener)
		{
			_eventListeners.TryAdd(eventName, null);

			_eventListeners[eventName] += WrappedListener;
			return;

			void WrappedListener(object data) => listener((T) data);
		}

		public void RemoveListener<T>(EventType eventName, Action<T> listener)
		{
			if (_eventListeners.ContainsKey(eventName))
			{
				_eventListeners[eventName] -= WrappedListener;
			}

			return;

			void WrappedListener(object data) => listener((T) data);
		}

		public void DispatchEvent<T>(EventType eventName, T data)
		{
			if (_eventListeners.TryGetValue(eventName, out var listener))
			{
				listener?.Invoke(data);
			}
		}
	}

	public enum EventType
	{
		None = 0,
		PlayerAction = 1,
		EnemyAction = 2,
		EndTurn = 3,
		GameOver = 4,
	}
}