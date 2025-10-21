using System.Collections.Generic;
using Code.Application.Ports;
using Code.Domain;
using Code.Unity.GameField.Nodes;

namespace Code.Unity.Services
{
    public class NodesRegistry : INodesRegistry
    {
        private readonly Dictionary<Position, NodeDisplay> _nodes = new();

        public TNodeType GetNodeAt<TNodeType>(Position position) where TNodeType : NodeDisplay
        {
            if (_nodes.TryGetValue(position, out var node) && node is TNodeType typed)
            {
                return typed;
            }

            throw new KeyNotFoundException($"Node of type {typeof(TNodeType)} not found at position {position}");
        }

        public void Set<TNodeType>(Position position, TNodeType node) where TNodeType : NodeDisplay
        {
            _nodes[position] = node;
        }
        
        public void Remove(Position position)
        {
            _nodes.Remove(position);
        }
    }
}