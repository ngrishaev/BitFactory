using Code.Domain;
using Code.Unity;
using Code.Unity.GameField.Builder;
using Code.Unity.GameField.Palette;
using NUnit.Framework;
using UnityEngine;

namespace Tests.Unity.Palette
{
    [TestFixture]
    public class NodeBuilderTests
    {
        [Test]
        public void NodeBuilder_BuildNodeAtGivenPosition_CreatesNode()
        {
            var root = new GameObject("Node builder nodes root").AddComponent<RectTransform>();
            var builder = new GameObject("Node builder").AddComponent<NodeBuilder>();
            var prefabData = new NodesPrefabMap.NodeMapData
            {
                Type = NodeType.ConnectorHorizontal,
                Prefab = new GameObject("Test ConnectorHorizontal Node")
            };
            PrivateField.Set(builder, "_root", root);

            var node = builder.Build(at: new Vector2Int(2, 3), node: prefabData.Prefab);
            
            Assert.NotNull(node);
            Assert.AreEqual(node.transform.localPosition.x, GlobalData.CellSize * 2);
            Assert.AreEqual(node.transform.localPosition.y, GlobalData.CellSize * 3);
        }
    }
}