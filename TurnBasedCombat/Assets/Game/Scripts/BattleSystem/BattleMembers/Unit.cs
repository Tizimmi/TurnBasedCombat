using Game.Scripts.BattleSystem.Abilities;
using Game.Scripts.ReactivePropertyModule;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.BattleSystem.BattleMembers 
{
    public class Unit
    {
        public int MaxHealth;
        public ReactiveProperty<int> CurrentHealth;
        public List<IAbility> Abilities;

        public Unit(int maxHealth, List<IAbility> abilities)
        {
            MaxHealth = maxHealth;
            CurrentHealth = new ReactiveProperty<int>(maxHealth);
            Abilities = abilities;
        }

        public void UseRandomAbility(Unit target)
        {
            var randAbility = Abilities[Random.Range(0, Abilities.Count)];
            UseAbility(randAbility, target);
        }
        
        public void UseAbility(IAbility ability, Unit target)
        {
        
            if (ability != null)
            {
                ability.Execute();// уйдет в стратегию
            }
            else
            {
                Debug.LogError("This entity does not have chosen ability");
            }
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth.Value = Mathf.Max(CurrentHealth.Value - damage, 0);
        
            Debug.Log($"I took {damage} damage");

            if (CurrentHealth.Value != 0)
                return;

            Death();
        }

        private void Death()
        {
            Debug.Log("I'm dead");
        }
    }
}