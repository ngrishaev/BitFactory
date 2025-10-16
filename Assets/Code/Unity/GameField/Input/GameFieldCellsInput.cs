using System;
using Code.Application.Ports;
using Code.Unity.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Unity.GameField.Input
{
    public class GameFieldCellsInput: MonoBehaviour, IGameFieldInput
    {
        [SerializeField] private Button _gameFieldGlobalButton;
        [SerializeField] private Button _tickButton;
        [SerializeField] private RectTransform _root;
        [SerializeField] private UserInputProvider _inputProvider; // TODO: Make service locator or add VContainer
        
        private IUserInputProvider _userInputProvider;

        public event Action<Vector2Int> OnCellClicked;
        public event Action OnNextTickClicked;

        private void Awake()
        {
            Construct(_inputProvider); 
        }

        public void Construct(IUserInputProvider userInputProvider)
        {
            _userInputProvider = userInputProvider;
            _gameFieldGlobalButton.onClick.AddListener(OnClick);
            _tickButton.onClick.AddListener(OnTick);
        }

        private void OnClick()
        {
            var localMousePosition = _root.InverseTransformPoint(_userInputProvider.MousePosition());
            var cellPosition = new Vector2Int(
                Mathf.FloorToInt(localMousePosition.x / GlobalData.CellSize),
                Mathf.FloorToInt(localMousePosition.y / GlobalData.CellSize));
            OnCellClicked?.Invoke(cellPosition);
        }

        private void OnTick()
        {
            OnNextTickClicked?.Invoke();
        }
    }
}