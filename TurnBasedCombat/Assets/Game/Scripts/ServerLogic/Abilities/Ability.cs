public interface IAbility
{
	public void Execute();
}

public interface IReloadable
{
	public int ReloadTime { get; }
}
