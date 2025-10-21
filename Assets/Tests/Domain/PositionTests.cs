using Code.Domain;
using NUnit.Framework;

namespace Tests.Domain
{
    [TestFixture]
    public class PositionTests
    {
        [Test]
        public void ZeroPosition()
        {
            Assert.AreEqual(Position.Zero.X, 0);
            Assert.AreEqual(Position.Zero.Y, 0);
        }

        [Test]
        public void CreatePosition_HoldSameValues()
        {
            var position = new Position(3, 5);
            
            Assert.AreEqual(position.X, 3);
            Assert.AreEqual(position.Y, 5);
        }
        
        [Test]
        public void PositionUpFromZero()
        {
            var position = Position.Zero.Up();
            
            Assert.AreEqual(position.X, 0);
            Assert.AreEqual(position.Y, 1);
        }

        [Test]
        public void PositionDownFromZero()
        {
            var position = Position.Zero.Down();
            
            Assert.AreEqual(position.X, 0);
            Assert.AreEqual(position.Y, -1);
        }
        
        [Test]
        public void PositionLeftFromZero()
        {
            var position = Position.Zero.Left();
            
            Assert.AreEqual(position.X, -1);
            Assert.AreEqual(position.Y, 0);
        }
        
        [Test]
        public void PositionRightFromZero()
        {
            var position = Position.Zero.Right();
            
            Assert.AreEqual(position.X, 1);
            Assert.AreEqual(position.Y, 0);
        }
    }
}