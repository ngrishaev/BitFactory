using Code.Domain;
using Code.Domain.Nodes;
using Code.Unity.GameField.Nodes;

namespace Code.Application.Ports
{
    public interface IGameFieldNodeBuilder
    {
        TNodeType Build<TNodeType>(Position at, TNodeType node, Rotation rotation) where TNodeType: NodeDisplay;
    }
}