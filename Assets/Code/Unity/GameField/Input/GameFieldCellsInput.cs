using System;
using Code.Application.Ports;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Unity.GameField.Input
{
    // TODO: Add to tests? Need to abstract UnityEngine.Input.mousePosition
    public class GameFieldCellsInput: MonoBehaviour, IGameFieldInput
    {
        [SerializeField] private Button _gameFieldGlobalButton;
        [SerializeField] private RectTransform _root;
        
        public event Action<Vector2Int> OnCellClicked; 

        private void Awake()
        {
            Construct();
        }

        private void Construct()
        {
            _gameFieldGlobalButton.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            var localMousePosition = _root.InverseTransformPoint(UnityEngine.Input.mousePosition);
            var cellPosition = new Vector2Int(
                Mathf.FloorToInt(localMousePosition.x / GlobalData.CellSize),
                Mathf.FloorToInt(localMousePosition.y / GlobalData.CellSize));
            OnCellClicked?.Invoke(cellPosition);
        }
    }
}