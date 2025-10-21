using Code.Domain.Nodes;
using NaughtyAttributes;
using UnityEngine;

namespace Code.Unity.GameField.Nodes
{
    public abstract class NodeDisplay: MonoBehaviour
    {
        [SerializeField, Required] private RectTransform _icon = null!;
        
        public void Rotate(Rotation rotation)
        {
            _icon.transform.rotation = Quaternion.Euler(0, 0, rotation.ToDegree());
        }
    }
}