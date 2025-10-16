namespace Code.Domain.Nodes
{
    public abstract class FieldNode
    {
        // TODO: Should be incapsulated
        public NodeType Type;
        public Rotation Rotation;
        protected FieldPacket Packet;

        protected abstract bool CanAcceptPacketFrom(NodeSide side);

        // TODO: Generate tests on that
        public bool TryAcceptPacketFrom(NodeSide side, FieldPacket packet)
        {
            if (CanAcceptPacketFrom(side))
            {
                Packet = packet;
                return true;
            }

            return false;
        }

        // TODO: Generate tests on that
        public bool HavePacket()
        {
            return Packet != null;
        }
    }
}