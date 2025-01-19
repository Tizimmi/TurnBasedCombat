// using Game.Scripts.BattleSystem.Abilities;
// using Game.Scripts.ClientLogic.UI.BaseClasses;
// using Game.Scripts.ReactivePropertyModule;
// using UnityEngine;
// using UnityEngine.UI;
//
// namespace Game.Scripts.ClientLogic.UI.PlayerInterface
// {
// 	public class AbilitySelectorView : View<AbilitySelectorVieModel>
// 	{
// 		[SerializeField]
// 		private Transform _container;
// 		[SerializeField]
// 		private Button _selectButton;
// 		[SerializeField]
// 		private AbilityButtonView _attackButton;
// 		[SerializeField]
// 		private AbilityButtonView _barrierButton;
// 		[SerializeField]
// 		private AbilityButtonView _regenerationButton;
// 		[SerializeField]
// 		private AbilityButtonView _fireballButton;
// 		[SerializeField]
// 		private AbilityButtonView _cleanseButton;
//
// 		public void Show()
// 		{
// 			_container.gameObject.SetActive(true);
// 		}
//
// 		public void Hide()
// 		{
// 			_container.gameObject.SetActive(false);
// 		}
//
// 		protected override void OnBind(AbilitySelectorVieModel viewModel)
// 		{
// 			_selectButton.onClick.AddListener(viewModel.ClickHandler);
//
// 			_attackButton.Bind(viewModel.DefaultAttackModel);
// 			_barrierButton.Bind(viewModel.BarrierModel);
// 			_regenerationButton.Bind(viewModel.RegenerationModel);
// 			_fireballButton.Bind(viewModel.FireballModel);
// 			_cleanseButton.Bind(viewModel.CleanseModel);
// 		}
//
// 		protected override void OnUnbind(AbilitySelectorVieModel viewModel)
// 		{
// 			_selectButton.onClick.RemoveListener(viewModel.ClickHandler);
//
// 			_attackButton.Unbind();
// 			_barrierButton.Unbind();
// 			_regenerationButton.Unbind();
// 			_fireballButton.Unbind();
// 			_cleanseButton.Unbind();
// 		}
// 	}
//
// 	public class AbilitySelectorVieModel : ViewModel
// 	{
// 		public IReadOnlyReactiveProperty<AbilityType> CurrentType => _currentType;
//
// 		public AbilityButtonViewModel DefaultAttackModel { get; set; }
// 		public AbilityButtonViewModel BarrierModel { get; set; }
// 		public AbilityButtonViewModel RegenerationModel { get; set; }
// 		public AbilityButtonViewModel FireballModel { get; set; }
// 		public AbilityButtonViewModel CleanseModel { get; set; }
// 		private readonly ReactiveProperty<AbilityType> _currentType;
//
// 		public void ClickHandler() { }
// 	}
// }