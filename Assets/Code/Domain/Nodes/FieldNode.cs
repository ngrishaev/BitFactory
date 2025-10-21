namespace Code.Domain.Nodes
{
    public abstract class FieldNode
    {
        // TODO: Should be incapsulated
        public NodeType Type;
        public Rotation Rotation;
        private FieldPacket? _packet;
        public Position Position;

        protected FieldNode(Position position)
        {
            Position = position;
        }

        public abstract bool CanAcceptPacketFrom(NodeSide side);
        
        public bool TryAcceptPacketFrom(NodeSide side, FieldPacket packet)
        {
            if (!CanAcceptPacketFrom(side))
                return false;
            
            _packet = packet;
            return true;
        }
        
        public bool HavePacket()
        {
            return _packet != null;
        }
    }
}