using Code.Domain;
using Code.Domain.Nodes;
using NUnit.Framework;

namespace Tests.Domain.Connectors
{
    [TestFixture]
    public class ConnectorHTests
    {
        [Test]
        public void NewlyCreatedNodesHaveNoPacket_Pass()
        {
            var connector = new ConnectorH(Rotation.Clockwise0);
            
            Assert.IsFalse(connector.HavePacket());
        }
        
        [Test]
        public void ReceiveFromLeftNoRotation_Accept()
        {
            var connector = new ConnectorH(Rotation.Clockwise0);
            
            Assert.IsTrue(connector.TryAcceptPacketFrom(NodeSide.Left, new FieldPacket()));
            Assert.IsTrue(connector.HavePacket());
        }
        
        [Test]
        public void ReceiveFromLeftRotation180_Accept()
        {
            var connector = new ConnectorH(Rotation.Clockwise180);
            
            Assert.IsTrue(connector.TryAcceptPacketFrom(NodeSide.Left, new FieldPacket()));
            Assert.IsTrue(connector.HavePacket());
        }
        
        [Test]
        public void ReceiveFromLeftRotation90_NoAccept()
        {
            var connector = new ConnectorH(Rotation.Clockwise90);
            
            Assert.IsFalse(connector.TryAcceptPacketFrom(NodeSide.Left, new FieldPacket()));
            Assert.IsFalse(connector.HavePacket());
        }
        
        [Test]
        public void ReceiveFromLeftRotation270_NoAccept()
        {
            var connector = new ConnectorH(Rotation.Clockwise270);
            
            Assert.IsFalse(connector.TryAcceptPacketFrom(NodeSide.Left, new FieldPacket()));
            Assert.IsFalse(connector.HavePacket());
        }
        
        [Test]
        public void ReceiveFromTopRotation0_NoAccept()
        {
            var connector = new ConnectorH(Rotation.Clockwise0);
            
            Assert.IsFalse(connector.TryAcceptPacketFrom(NodeSide.Top, new FieldPacket()));
            Assert.IsFalse(connector.HavePacket());
        }
    }
}