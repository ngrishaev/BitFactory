namespace Code.Domain.Nodes
{
    public class ConnectorL : FieldNode
    {
        public ConnectorL(Rotation rotation, Position position) : base(position)
        {
            Rotation = rotation;
            Type = NodeType.ConnectorL;
        }

        public override bool CanAcceptPacketFrom(NodeSide side)
        {
            if (HavePacket())
            {
                return false;
            }
            
            return side == NodeSide.Left && Rotation is Rotation.Clockwise180 or Rotation.Clockwise270
                   || side == NodeSide.Top && Rotation is Rotation.Clockwise0 or Rotation.Clockwise270
                   || side == NodeSide.Right && Rotation is Rotation.Clockwise0 or Rotation.Clockwise90
                   || side == NodeSide.Bottom && Rotation is Rotation.Clockwise90 or Rotation.Clockwise180;
        }
    }
}