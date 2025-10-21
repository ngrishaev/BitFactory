using Code.Domain;
using Code.Domain.Nodes;
using NUnit.Framework;

namespace Tests.Domain
{
    [TestFixture]
    public class GameFieldTests
    {
        [Test]
        public void GameField_InitializeWithWidthAndHeight_CanCreateNode()
        {
            var field = new GameField(8, 8);

            var fieldNode = new ConnectorH(Rotation.Clockwise0, Position.Zero);
            field.SetNode(Position.Zero, fieldNode);
            var returnedNode = field.GetNodeAt(Position.Zero);
            
            Assert.AreSame(returnedNode, fieldNode);
        }
        
        [Test]
        public void GameField_NoNodesByDefault()
        {
            var field = new GameField(8, 8);
            
            var returnedNode = field.GetNodeAt(Position.Zero);
            
            Assert.IsNull(returnedNode);
        }
    }
}