using Code.Domain.Nodes;

namespace Code.Domain
{
    public class Spawner
    {
        private readonly IField _field;
        private int _posX;
        private int _posY;

        public Spawner(IField field)
        {
            _field = field;
        }

        public void Tick()
        {
            // TODO: this is a hardcoded position.
            // TODO: make position as separate class
            // TODO: make spawner position configurable
            var node = _field.GetNodeAt(_posX + 1, _posY);

            // TODO: this is a hardcoded side. Should be calculatable
            node?.TryAcceptPacketFrom(NodeSide.Left, new FieldPacket());
        }
    }

    public interface IField
    {
        FieldNode? GetNodeAt(int posX, int posY);
    }
}