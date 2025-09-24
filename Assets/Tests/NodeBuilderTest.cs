using Code.Unity;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    [TestFixture]
    public class NodeBuilderTest
    {
        [Test]
        public void NodeBuilder_BuildNodeAtGivenPosition_CreatesNode()
        {
            var root = new GameObject().AddComponent<RectTransform>();
            var builder = new GameObject().AddComponent<NodeBuilder>();
            var prefabData = new NodesPrefabMap.NodeMapData
            {
                Type = NodesPrefabMap.EntityType.ConnectorHorizontal,
                Prefab = new GameObject("Test ConnectorHorizontal Node")
            };
            PrivateField.Set(builder, "_root", root);

            var node = builder.Build(at: new Vector2Int(2, 3), prefab: prefabData.Prefab);
            
            Assert.NotNull(node);
            Assert.AreEqual(node.transform.localPosition.x, 100*2); // TODO: Вынести "100" в конфиги, думаю, стоит. Или константы.
            Assert.AreEqual(node.transform.localPosition.y, 100*3);
        }
    }
}