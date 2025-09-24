using UnityEngine;

namespace Code.Unity.Palette
{
    public class NodesPalette : MonoBehaviour
    {
        [SerializeField] private NodesPaletteElement _horizontalConnector;
        [SerializeField] private NodesPaletteElement _lConnector;
        private NodesPaletteElement _currentElement;

        private void Awake()
        {
            Construct();
        }

        public void Construct()
        {
            _horizontalConnector.OnClicked += OnElementClicked;
            _lConnector.OnClicked += OnElementClicked;
        }

        private void OnElementClicked(NodesPaletteElement clickedElement)
        {
            _currentElement?.Deselect();
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
