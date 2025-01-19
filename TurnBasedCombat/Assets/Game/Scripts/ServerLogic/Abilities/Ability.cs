using Game.Scripts.BattleSystem.BattleMembers;

namespace Game.Scripts.ServerLogic.Abilities {
	
	public interface IAbility
	{
		public void Execute();
		public AbilityType Type { get; }
	}

	public interface IReloadable
	{
		public int ReloadTime { get; }
	}

	public interface ITargetable
	{
		public Unit Target { get; }
	}

	public interface ISelfTargetable
	{
		public Unit Self { get; }
	}
}