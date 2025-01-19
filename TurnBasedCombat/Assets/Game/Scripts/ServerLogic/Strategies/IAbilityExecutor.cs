using Game.Scripts.ServerLogic.Abilities;

namespace Game.Scripts.ServerLogic.Strategies
{
	public interface IAbilityExecutor
	{
		public bool TryExecute(IAbility ability);
	}
}
