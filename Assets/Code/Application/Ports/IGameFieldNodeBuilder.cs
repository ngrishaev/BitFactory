using Code.Domain;
using Code.Unity.GameField.Nodes;

namespace Code.Application.Ports
{
    public interface IGameFieldNodeBuilder
    {
        TNodeType Build<TNodeType>(Position at, TNodeType node) where TNodeType: NodeDisplay;
    }
}