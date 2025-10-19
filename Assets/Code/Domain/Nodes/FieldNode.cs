namespace Code.Domain.Nodes
{
    public abstract class FieldNode
    {
        // TODO: Should be incapsulated
        public NodeType Type;
        public Rotation Rotation;
        private FieldPacket? _packet;

        protected abstract bool CanAcceptPacketFrom(NodeSide side);
        
        public bool TryAcceptPacketFrom(NodeSide side, FieldPacket packet)
        {
            if (CanAcceptPacketFrom(side))
            {
                _packet = packet;
                return true;
            }

            return false;
        }
        
        public bool HavePacket()
        {
            return _packet != null;
        }
    }
}