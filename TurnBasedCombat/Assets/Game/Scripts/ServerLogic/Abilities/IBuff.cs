using Game.Scripts.BattleSystem.BattleMembers;

namespace Game.Scripts.ServerLogic.Abilities
{
	public interface IBuff
	{
		public void StartEffect(Unit unit);
		public int Duration { get; }
	}
}