using Game.Scripts.BattleSystem.BattleMembers;

namespace Game.Scripts.ServerLogic.Strategies
{
	public class DefaultAttack : IAbility
	{
		private readonly Unit _target;
		private readonly int _damage;

		public DefaultAttack(Unit target, int damage)
		{
			_target = target;
			_damage = damage;
		}
		
		public void Execute()
		{
			_target.TakeDamage(_damage);
		}
	}
}