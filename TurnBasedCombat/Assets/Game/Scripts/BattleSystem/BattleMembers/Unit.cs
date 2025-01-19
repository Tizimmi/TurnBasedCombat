using Game.Scripts.ReactivePropertyModule;
using Game.Scripts.ServerLogic.Abilities;
using Game.Scripts.ServerLogic.Strategies;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Scripts.BattleSystem.BattleMembers
{
	public class Unit
	{
		public int MaxHealth;
		public ReactiveProperty<int> CurrentHealth;
		public List<IAbility> Abilities = new();

		public Unit(int maxHealth)
		{
			MaxHealth = maxHealth;
			CurrentHealth = new ReactiveProperty<int>(maxHealth);
		}

		public IAbility UseRandomAbility()
		{
			return UseAbility(Abilities[Random.Range(0, Abilities.Count)].Type);
		}

		public IAbility UseAbility(AbilityType attackType)
		{
			var ability = Abilities.Find(x => x.Type == attackType);
			
			if (ability is IReloadable)
			{
				var executor = new ReloadableAbilityExecutor(new DefaultAbilityExecutor());
				executor.TryExecute(ability);
			}
			else
			{
				var executor = new DefaultAbilityExecutor();
				executor.TryExecute(ability);
			}

			return ability;
		}

		private IAbility UseAbility(IAbility ability)
		{
			if (ability is IReloadable)
			{
				var executor = new ReloadableAbilityExecutor(new DefaultAbilityExecutor());
				executor.TryExecute(ability);
			}
			else
			{
				var executor = new DefaultAbilityExecutor();
				executor.TryExecute(ability);
			}

			return ability;
		}

		public void ReduceHealth(int value)
		{
			CurrentHealth.Value = Mathf.Max(CurrentHealth.Value - value, 0);

			Debug.Log($"I took {value} damage");

			if (CurrentHealth.Value != 0)
				return;

			Death();
		}

		public void IncreaseHealth(int value)
		{
			CurrentHealth.Value = Mathf.Min(CurrentHealth.Value + value, MaxHealth);
		}

		private void Death()
		{
			Debug.Log("I'm dead");
		}

		public void ApplyEffect(IBuff effect)
		{
			effect.StartEffect(this);
		}

		public void UpdateBuffs()
		{
			
		}

		public void UpdateCooldowns()
		{
			
		}
	}
}