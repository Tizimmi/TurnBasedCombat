using Game.Scripts.BattleSystem.BattleMembers;

namespace Game.Scripts.ServerLogic.Abilities
{
	public class Regeneration : IAbility, ISelfTargetable, IReloadable, IBuff
	{
		public Unit Self { get; }
		public int ReloadTime { get; }
		public int Duration { get; }
		public AbilityType Type { get; }

		private readonly int _healingPerTurn;

		public Regeneration(Unit self, int duration, int reloadTime,
			int healingPerTurn,
			AbilityType type)
		{
			Self = self;
			ReloadTime = reloadTime;
			_healingPerTurn = healingPerTurn;
			Type = type;
			Duration = duration;
		}

		public void Execute()
		{
			Self.ApplyEffect(this);
		}

		public void StartEffect(Unit unit)
		{
			unit.IncreaseHealth(_healingPerTurn);
		}
	}
}