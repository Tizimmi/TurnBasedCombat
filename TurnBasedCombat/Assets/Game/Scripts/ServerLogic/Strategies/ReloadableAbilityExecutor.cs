using Game.Scripts.ServerLogic.Abilities;
using System.Collections.Generic;

namespace Game.Scripts.ServerLogic.Strategies
{
	public class ReloadableAbilityExecutor : IAbilityExecutor
	{
		private readonly IAbilityExecutor _coreExecutor;
		private Dictionary<IReloadable, int> _itemsOnCooldown;

		public ReloadableAbilityExecutor(IAbilityExecutor coreExecutor)
		{
			_coreExecutor = coreExecutor;
		}
		
		public bool TryExecute(IAbility ability)
		{
			if (ability is IReloadable reloadable)
			{
				if (_itemsOnCooldown.ContainsKey(reloadable))
				{
					return false;
				}
				_itemsOnCooldown.Add(reloadable, reloadable.ReloadTime);
			}
			
			_coreExecutor.TryExecute(ability);
			return true;
		}
	}
}