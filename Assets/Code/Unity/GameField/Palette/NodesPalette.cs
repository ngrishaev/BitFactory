using System.Diagnostics.CodeAnalysis;
using Code.Application.Ports;
using Code.Unity.Services;
using NaughtyAttributes;
using UnityEngine;

namespace Code.Unity.GameField.Palette
{
    public class NodesPalette : MonoBehaviour, IGameFieldPalette
    {
        [SerializeField, Required] private NodesPaletteElement _horizontalConnector = null!;
        [SerializeField, Required] private NodesPaletteElement _lConnector = null!;
        // TODO: Make service locator or add VContainer
        [SerializeField, Required] private UserInputProvider _inputProvider = null!;
        
        private IUserInputProvider _userInputProvider = null!;
        private NodesPaletteElement? _currentElement;

        [ExcludeFromCodeCoverage]
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

        public NodesPaletteElement? CurrentlySelected()
        {
            return _currentElement;
        }
    }
}
