﻿using System;

namespace Game.Scripts.ReactivePropertyModule
{
	public class ReactiveProperty<TValue> : IReadOnlyReactiveProperty<TValue>
	{
		public event Action<TValue> OnValueChange;

		public TValue Value
		{
			get => _value;
			set
			{
				if (!_value.Equals(value))
				{
					_value = value;
					OnValueChange?.Invoke(_value);
				}
			}
		}

		private TValue _value;

		public ReactiveProperty(TValue value)
		{
			_value = value;
		}

		public void SilentSetValue(TValue value)
		{
			_value = value;
		}
	}

	public interface IReadOnlyReactiveProperty<TValue>
	{
		public event Action<TValue> OnValueChange;
		public TValue Value { get; set; }
	}
}