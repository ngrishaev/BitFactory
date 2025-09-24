using Code.Domain;
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

            var fieldNode = new FieldNode() { Type = NodeType.ConnectorHorizontal, Rotation = Rotation.None };
            field.SetNode(0, 0, fieldNode);
            var returnedNode = field.GetAt(0, 0);
            
            Assert.AreSame(returnedNode, fieldNode);
        }
        
        [Test]
        public void GameField_NoNodesByDefault()
        {
            var field = new GameField(8, 8);
            
            var returnedNode = field.GetAt(0, 0);
            
            Assert.IsNull(returnedNode);
        }
        
    }
}