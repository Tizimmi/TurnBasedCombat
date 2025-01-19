using Game.Scripts.BattleSystem.BattleMembers;
using Game.Scripts.ClientLogic.UI.BaseClasses;
using Game.Scripts.ServerLogic.Abilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.ClientLogic.UI.PlayerInterface
{
	public class UnitDisplayView : View<UnitDisplayViewModel>
	{
		[SerializeField]
		private Image _healthBar;
		[SerializeField]
		private TextMeshProUGUI _healthField;

		protected override void OnBind(UnitDisplayViewModel viewModel)
		{
			CurrentHealthOnOnValueChange(viewModel.Unit.MaxHealth);
			viewModel.Unit.CurrentHealth.OnValueChange += CurrentHealthOnOnValueChange;
		}

		protected override void OnUnbind(UnitDisplayViewModel viewModel)
		{
			viewModel.Unit.CurrentHealth.OnValueChange -= CurrentHealthOnOnValueChange;
		}

		private void CurrentHealthOnOnValueChange(int health)
		{
			_healthBar.fillAmount = (float)health / ViewModel.Unit.MaxHealth;
			_healthField.text = $"{health}/{ViewModel.Unit.MaxHealth}";
		}
	}

	public class UnitDisplayViewModel : ViewModel
	{
		public Unit Unit { get; }

		public UnitDisplayViewModel(Unit unit)
		{
			Unit = unit;
		}
	}
}