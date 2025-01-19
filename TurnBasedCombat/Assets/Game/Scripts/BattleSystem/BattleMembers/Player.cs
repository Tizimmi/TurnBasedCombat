using Game.Scripts.BattleSystem.Abilities;
using System.Collections.Generic;

namespace Game.Scripts.BattleSystem.BattleMembers
{
	public class Player : Unit
	{
		public Player(int maxHealth, List<IAbility> abilities)
			: base(maxHealth, abilities) { }
	}
}