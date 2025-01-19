using System;
using UnityEngine;

namespace Game.Scripts.ClientLogic.UI.BaseClasses
{
	public abstract class View<TViewModel> : MonoBehaviour, IView<TViewModel>
		where TViewModel : class, IViewModel
	{
		public TViewModel ViewModel { get; private set; }

		public void Bind(TViewModel viewModel)
		{
			Unbind();

			ViewModel = viewModel;
			OnBind(ViewModel);
		}

		public void Unbind()
		{
			if (ViewModel != null)
			{
				OnUnbind(ViewModel);
				ViewModel = null;
			}
		}

		public virtual void Dispose() { }

		protected virtual void OnBind(TViewModel viewModel)
		{
			Debug.Log($"Bind view model '{viewModel}' to view '{this}'");
		}

		protected virtual void OnUnbind(TViewModel viewModel)
		{
			Debug.Log($"Unbind view model '{viewModel}' from view '{this}'");
		}
	}

	public interface IView<in TViewModel> : IDisposable
		where TViewModel : class, IViewModel
	{
		void Bind(TViewModel viewModel);
		void Unbind();
	}
}