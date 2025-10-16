using System;
using Code.Domain;
using Code.Domain.Nodes;
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

        public NodeType NodeType()
        {
            return _nodeData.Type;
        }
        
        public Rotation Rotation()
        {
            return RotationFromAngle(Mathf.RoundToInt(_icon.transform.rotation.eulerAngles.z));
        }

        private Rotation RotationFromAngle(int degrees)
        {
            return degrees switch
            {
                0 => Domain.Nodes.Rotation.Clockwise0,
                90 => Domain.Nodes.Rotation.Clockwise270,
                180 => Domain.Nodes.Rotation.Clockwise180,
                270 => Domain.Nodes.Rotation.Clockwise90,
                _ => throw new ArgumentOutOfRangeException(nameof(degrees), degrees, null)
            };
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
            var newAngle = Mathf.RoundToInt(_icon.transform.rotation.eulerAngles.z - 90) % 360;
            _icon.transform.rotation = Quaternion.Euler(0, 0, newAngle);
        }

        public void ResetRotation()
        {
            _icon.transform.rotation = Quaternion.identity;
        }
    }
}
