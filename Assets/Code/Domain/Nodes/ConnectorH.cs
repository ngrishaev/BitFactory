namespace Code.Domain.Nodes
{
    public class ConnectorH : FieldNode
    {
        public ConnectorH(Rotation rotation)
        {
            Rotation = rotation;
            Type = NodeType.ConnectorHorizontal;
        }
        
        protected override bool CanAcceptPacketFrom(NodeSide side)
        {
            if (HavePacket())
            {
                return false;
            }
            
            return side is NodeSide.Left or NodeSide.Right && Rotation is Rotation.Clockwise0 or Rotation.Clockwise180
                   || side is NodeSide.Bottom or NodeSide.Top && Rotation is Rotation.Clockwise90 or Rotation.Clockwise270;
        }
    }
}