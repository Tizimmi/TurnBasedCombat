using Game.Scripts.BattleSystem.BattleMembers;
using UnityEngine;

namespace Game.Scripts.ServerLogic.Abilities
{
	public class DefaultAttack : IAbility, ITargetable
	{
		public Unit Target { get; }
		private readonly int _damage;
		public AbilityType Type { get; }


		public DefaultAttack(Unit target, int damage, AbilityType type)
		{
			Target = target;
			_damage = damage;
			Type = type;
		}

		public void Execute()
		{
			Debug.Log($"Attacked for {_damage}");
			Target.ReduceHealth(_damage);
		}
	}
}