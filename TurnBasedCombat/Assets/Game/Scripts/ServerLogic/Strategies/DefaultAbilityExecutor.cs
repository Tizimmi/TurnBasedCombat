namespace Game.Scripts.ServerLogic.Strategies
{
	public class DefaultAbilityExecutor : IAbilityExecutor
	{
		public bool TryExecute(IAbility ability)
		{
			ability.Execute();
			return true;
		}
	}
}