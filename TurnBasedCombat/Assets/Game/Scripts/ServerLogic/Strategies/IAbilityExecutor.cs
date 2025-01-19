namespace Game.Scripts.ServerLogic.Strategies
{
	public interface IAbilityExecutor
	{
		public bool TryExecute(IAbility ability);
	}
}
