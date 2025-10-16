using Code.Domain;
using Code.Domain.Nodes;
using NUnit.Framework;

namespace Tests.Domain
{
    [TestFixture]
    public class SpawnerTests
    {
        // TODO: add more tests on spawner and on newly created nodetypes
        [Test]
        public void Spawner_HaveAvailableConnectorToTheRight_PassPacket()
        {
            var fieldServiceStub = new FieldStub();
            var spawner = new Spawner(fieldServiceStub);

            spawner.Tick();
            
            Assert.IsTrue(fieldServiceStub.HavePacketAt(0, 7));
        }
    }

    public class FieldStub : IField
    {
        private FieldNode _node;

        public FieldStub()
        {
            _node = new ConnectorH(Rotation.Clockwise0);
        }
        
        public bool? HavePacketAt(int x, int y)
        {
            return _node.HavePacket();
        }

        public FieldNode GetNodeAt(int posX, int posY)
        {
            return _node;
        }
    }
}