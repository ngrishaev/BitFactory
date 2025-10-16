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
        
        [Test]
        public void ReceiveFromLeftNoRotation_NoAccept()
        {
            var connector = new ConnectorL(Rotation.Clockwise0);
            
            Assert.IsFalse(connector.TryAcceptPacketFrom(NodeSide.Left, new FieldPacket()));
            Assert.IsFalse(connector.HavePacket());
        }
        
        [Test]
        public void ReceiveFromTopNoRotation_Accept()
        {
            var connector = new ConnectorL(Rotation.Clockwise0);
            
            Assert.IsTrue(connector.TryAcceptPacketFrom(NodeSide.Top, new FieldPacket()));
            Assert.IsTrue(connector.HavePacket());
        }
        
        [Test]
        public void ReceiveFromLeftRotation180_Accept()
        {
            var connector = new ConnectorL(Rotation.Clockwise180);
            
            Assert.IsTrue(connector.TryAcceptPacketFrom(NodeSide.Left, new FieldPacket()));
            Assert.IsTrue(connector.HavePacket());
        }
        
        [Test]
        public void ReceiveFromLeftRotation270_Accept()
        {
            var connector = new ConnectorL(Rotation.Clockwise270);
            
            Assert.IsTrue(connector.TryAcceptPacketFrom(NodeSide.Left, new FieldPacket()));
            Assert.IsTrue(connector.HavePacket());
        }
    }
}