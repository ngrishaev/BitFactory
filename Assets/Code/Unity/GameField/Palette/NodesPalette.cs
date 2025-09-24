using Code.Application.Ports;
using Code.Unity.GameField.Input;
using Code.Unity.Services;
using UnityEngine;

namespace Code.Unity.GameField.Palette
{
    public class NodesPalette : MonoBehaviour, IGameFieldPalette
    {
        [SerializeField] private NodesPaletteElement _horizontalConnector;
        [SerializeField] private NodesPaletteElement _lConnector;
        [SerializeField] private UserInputProvider _inputProvider; // TODO: Make service locator or add VContainer
        private NodesPaletteElement _currentElement;
        private IUserInputProvider _userInputProvider;

        private void Awake()
        {
            Construct(_inputProvider); 
        }

        public void Construct(IUserInputProvider userInputProvider)
        {
            _userInputProvider = userInputProvider;
            _horizontalConnector.OnClicked += OnElementClicked;
            _lConnector.OnClicked += OnElementClicked;
            _userInputProvider.OnRKeyPressed += OnRotationRequested;
        }

        private void OnRotationRequested()
        {
            if (_currentElement != null)
            {
                _currentElement.Rotate();
            }
        }

        private void OnElementClicked(NodesPaletteElement clickedElement)
        {
            _currentElement?.Deselect();
            _currentElement?.ResetRotation();
            if (_currentElement == clickedElement)
            {
                _currentElement = null;
                return;
            }
            
            _currentElement = clickedElement;
            _currentElement.Select();
        }

        public NodesPaletteElement CurrentlySelectedNode()
        {
            return _currentElement;
        }
    }
}
