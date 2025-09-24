using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Unity.GameField.Palette
{
    public class NodesPaletteElement : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private GameObject _highlight;
        [SerializeField] private GameObject _icon;
        [SerializeField] private NodesPrefabMap.NodeMapData _nodeData;
        
        public event Action<NodesPaletteElement> OnClicked;

        private void Awake()
        {
            Construct();
        }

        public void Construct()
        {
            _button.onClick.AddListener(() => OnClicked?.Invoke(this));
            _highlight.SetActive(false);
        }

        public void Select()
        {
            _highlight.SetActive(true);
        }

        public void Deselect()
        {
            _highlight.SetActive(false);
        }

        public void Rotate()
        {
            var newAngle = Mathf.RoundToInt(_icon.transform.rotation.eulerAngles.z + 90) % 360;
            _icon.transform.rotation = Quaternion.Euler(0, 0, newAngle);
        }

        public void ResetRotation()
        {
            _icon.transform.rotation = Quaternion.identity;
        }
    }
}
