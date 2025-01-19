using Game.Scripts.ServerLogic.Abilities;

namespace Game.Scripts.ServerLogic.Strategies
{
	public class UseRegenerationStrategy
	{
		private readonly Regeneration _regen;

		public UseRegenerationStrategy(Regeneration regen)
		{
			_regen = regen;
		}

		public void ApplyRegeneration()
		{
			var executor = new ReloadableAbilityExecutor(new DefaultAbilityExecutor());
			executor.TryExecute(_regen);
		}
	}
}