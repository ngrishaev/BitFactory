using Code.Application.Ports;
using UnityEngine;

namespace Code.Unity.GameField.Builder
{
    public class NodeBuilder: MonoBehaviour, IGameFieldNodeBuilder
    {
        [SerializeField] private RectTransform _root;
        
        public GameObject Build(Vector2Int at, GameObject node)
        {
            var instantiatedNode = Instantiate(node, _root);
            instantiatedNode.transform.localPosition = new Vector3(at.x * GlobalData.CellSize, at.y * GlobalData.CellSize, _root.transform.localPosition.z);
            return instantiatedNode;
        }
    }
}