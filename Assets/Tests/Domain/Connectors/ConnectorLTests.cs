using Code.Domain;
using Code.Domain.Nodes;
using NUnit.Framework;

namespace Tests.Domain.Connectors
{
    [TestFixture]
    public class ConnectorLTests
    {
        [Test]
        public void NewlyCreatedNodesHaveNoPacket_Pass()
        {
            var connector = new ConnectorL(Rotation.Clockwise0);
            
            Assert.IsFalse(connector.HavePacket());
        }
        
        [TestCase(NodeSide.Left, Rotation.Clockwise0)]
        [TestCase(NodeSide.Left, Rotation.Clockwise90)]
        [TestCase(NodeSide.Right, Rotation.Clockwise180)] 
        [TestCase(NodeSide.Right, Rotation.Clockwise270)] 
        [TestCase(NodeSide.Top, Rotation.Clockwise90)]
        [TestCase(NodeSide.Top, Rotation.Clockwise180)] 
        [TestCase(NodeSide.Bottom, Rotation.Clockwise0)]
        [TestCase(NodeSide.Bottom, Rotation.Clockwise270)] 
        public void Receive_Deny(NodeSide fromSide, Rotation rotation)
        {
            var connector = new ConnectorL(rotation);
            
            Assert.IsFalse(connector.TryAcceptPacketFrom(fromSide, new FieldPacket()));
            Assert.IsFalse(connector.HavePacket());
        }
        
        [TestCase(NodeSide.Left, Rotation.Clockwise180)] 
        [TestCase(NodeSide.Left, Rotation.Clockwise270)] 
        [TestCase(NodeSide.Right, Rotation.Clockwise0)] 
        [TestCase(NodeSide.Right, Rotation.Clockwise90)] 
        [TestCase(NodeSide.Top, Rotation.Clockwise0)] 
        [TestCase(NodeSide.Top, Rotation.Clockwise270)] 
        [TestCase(NodeSide.Bottom, Rotation.Clockwise90)] 
        [TestCase(NodeSide.Bottom, Rotation.Clockwise180)] 
        public void Receive_Accept(NodeSide fromSide, Rotation rotation)
        {
            var connector = new ConnectorL(rotation);
            
            Assert.IsTrue(connector.TryAcceptPacketFrom(fromSide, new FieldPacket()));
            Assert.IsTrue(connector.HavePacket());
        }
    }
}