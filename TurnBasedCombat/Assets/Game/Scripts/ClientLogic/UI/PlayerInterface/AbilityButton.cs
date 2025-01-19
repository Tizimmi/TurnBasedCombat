// using Game.Scripts.BattleSystem.Abilities;
// using Game.Scripts.ClientLogic.UI.BaseClasses;
// using Game.Scripts.ClientLogic.UI.BaseClasses.Implementations;
// using Game.Scripts.ReactivePropertyModule;
// using TMPro;
// using UnityEngine;
// using UnityEngine.UI;
//
// namespace Game.Scripts.ClientLogic.UI.PlayerInterface
// {
// 	public class AbilityButtonView : View<AbilityButtonViewModel>
// 	{
// 		[SerializeField]
// 		private TextMeshProUGUI _abilityName;
// 		[SerializeField]
// 		private Button _abilityButton;
// 		[SerializeField]
// 		private TextMeshProUGUI _cooldownText;
//
// 		protected override void OnBind(AbilityButtonViewModel viewModel)
// 		{
// 			_abilityName.text = viewModel.ModelValue.ToString();
//
// 			viewModel.Ability.CooldownTimer.OnValueChange += ChangeCooldownText;
// 			viewModel.Ability.IsOnCooldown.OnValueChange += ChangeInteractableState;
// 			viewModel.IsSelected.OnValueChange += ChangeSelectedState;
//
// 			_abilityButton.onClick.AddListener(viewModel.SetNewValue);
// 		}
//
// 		protected override void OnUnbind(AbilityButtonViewModel viewModel)
// 		{
// 			viewModel.Ability.CooldownTimer.OnValueChange -= ChangeCooldownText;
// 			viewModel.Ability.IsOnCooldown.OnValueChange -= ChangeInteractableState;
// 			viewModel.IsSelected.OnValueChange -= ChangeSelectedState;
//
// 			_abilityButton.onClick.RemoveListener(viewModel.SetNewValue);
// 		}
//
// 		private void ChangeCooldownText(int obj)
// 		{
// 			_cooldownText.text = obj == 0 ? string.Empty : "cooldown: " + obj;
// 		}
//
// 		private void ChangeInteractableState(bool isOnCooldown)
// 		{
// 			_abilityButton.interactable = !isOnCooldown;
// 		}
//
// 		private void ChangeSelectedState(bool isSelected)
// 		{
// 			_abilityButton.image.color = isSelected ? Color.gray : Color.white;
// 		}
// 	}
//
// 	public class AbilityButtonViewModel : SelectedElementModel<AbilityType>
// 	{
// 		public Ability Ability { get; }
//
// 		public AbilityButtonViewModel(ReactiveProperty<AbilityType> currentValue, Ability ability)
// 			: base(currentValue, ability.AbilityType)
// 		{
// 			Ability = ability;
// 		}
//
// 		public void SetNewValue()
// 		{
// 			SelectedValue.Value = ModelValue;
// 		}
// 	}
// }