using Game.Scripts.ReactivePropertyModule;

namespace Game.Scripts.ClientLogic.UI.BaseClasses.Implementations
{
	public abstract class SelectedElementModel<TValue> : ViewModel
	{
		public IReadOnlyReactiveProperty<TValue> SelectedValue => _selectedValue;
		public IReadOnlyReactiveProperty<bool> IsSelected => _isSelected;

		private readonly ReactiveProperty<bool> _isSelected = new(false);
		private readonly ReactiveProperty<TValue> _selectedValue;

		public readonly TValue ModelValue;

		protected SelectedElementModel(ReactiveProperty<TValue> selectedValue, TValue modelValue)
		{
			_selectedValue = selectedValue;
			ModelValue = modelValue;

			SelectedValue.OnValueChange += ChangeSelectedState;
		}

		protected virtual void ChangeSelectedState(TValue newValue)
		{
			IsSelected.Value = ModelValue.Equals(newValue);
		}
	}
}