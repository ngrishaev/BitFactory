using System;
using Code.Application.Ports;
using Code.Unity.Services;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;

namespace Code.Unity.GameField.Input
{
    public class GameFieldCellsInput: MonoBehaviour, IGameFieldInput
    {
        [SerializeField, Required] private Button _gameFieldGlobalButton = null!;
        [SerializeField, Required] private Button _tickButton = null!;
        [SerializeField, Required] private RectTransform _root = null!;
        [SerializeField, Required] private UserInputProvider _inputProvider = null!; // TODO: Make service locator or add VContainer
        
        private IUserInputProvider _userInputProvider = null!;

        public event Action<Vector2Int>? OnCellClicked;
        public event Action? OnNextTickClicked;

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