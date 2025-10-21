using Code.Application.Ports;
using Code.Domain;
using Code.Domain.Nodes;
using Code.Unity.GameField.Nodes;
using NaughtyAttributes;
using UnityEngine;

namespace Code.Unity.GameField.Builder
{
    public class NodeBuilder: MonoBehaviour, IGameFieldNodeBuilder
    {
        [SerializeField, Required] private RectTransform _root = null!;
        private INodesRegistry _nodesRegistry = null!;

        public void Construct(INodesRegistry nodesRegistry)
        {
            _nodesRegistry = nodesRegistry;
        }

        public TNodeType Build<TNodeType>(Position at, TNodeType node, Rotation rotation = Rotation.Clockwise0) where TNodeType : NodeDisplay
        {
            var instantiatedNode = Instantiate(node, _root);
            instantiatedNode.transform.localPosition = new Vector3(at.X * GlobalData.CellSize, at.Y * GlobalData.CellSize, _root.transform.localPosition.z);
            instantiatedNode.Rotate(rotation);
            _nodesRegistry.Set(at, instantiatedNode);
            return instantiatedNode;
        }
    }
}