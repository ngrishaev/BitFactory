using System.Linq;
using Code.Domain;
using Code.Domain.Nodes;
using NUnit.Framework;

namespace Tests.Domain
{
    [TestFixture]
    public class SpawnerTests
    {
        [Test]
        public void Spawner_HaveAvailableConnectorToTheRight_PassPacket()
        {
            var fieldServiceStub = new FieldStub();
            var spawner = new Spawner(fieldServiceStub, Position.Zero);

            spawner.PlanTick();
            spawner.ImplementPlannedTick();
            
            Assert.IsTrue(fieldServiceStub.HavePacketAt(0, 7));
        }
        
        // TODO: add more tests on spawner and on newly created nodetypes
        [Test]
        public void Spawner_PlanTicks_HaveOneSpawnPacketTickPlanned()
        {
            var fieldServiceStub = new FieldStub();
            var spawner = new Spawner(fieldServiceStub, Position.Zero);

            spawner.PlanTick();
            
            Assert.IsFalse(fieldServiceStub.HavePacketAt(0, 7));
            Assert.AreEqual(1, spawner.Ticks.Count);
            Assert.IsInstanceOf<SpawnPacketEvent>(spawner.Ticks.First());
        }
    }

    public class FieldStub : IField
    {
        private FieldNode _node;

        public FieldStub()
        {
            _node = new ConnectorH(Rotation.Clockwise0, Position.Zero);
        }
        
        public bool? HavePacketAt(int x, int y)
        {
            return _node.HavePacket();
        }

        public FieldNode? GetNodeAt(Position position)
        {
            return _node;
        }
    }
}