using Code.Domain;
using Code.Unity.GameField.Nodes;

namespace Code.Application.Ports
{
    public interface INodesRegistry
    {
        TNodeType GetNodeAt<TNodeType>(Position position) where TNodeType : NodeDisplay;
        void Set<TNodeType>(Position position, TNodeType node) where TNodeType : NodeDisplay;
        void Remove(Position position);
    }
}