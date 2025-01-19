using System;

namespace Game.Scripts.ClientLogic.UI.BaseClasses
{
	public abstract class ViewModel : IViewModel
	{
		public virtual void Dispose() { }
	}

	public interface IViewModel : IDisposable { }
}