using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    [TestFixture]
    public class NodesPaletteTests
    {
        [Test]
        public void NodesPalette_CurrentlySelectedNode_ReturnsNullByDefault()
        {
            var palette = NodesPaletteUtils.CreatePalette();
            
            Assert.IsNull(palette.Palette.CurrentlySelectedNode());
        }
        
        
        [Test]
        public void NodesPalette_SelectHConnector_NodeIsSelected()
        {
            var palette = NodesPaletteUtils.CreatePalette();
            
            palette.HConnector.Button.onClick.Invoke();
            
            Assert.IsTrue(palette.Palette.CurrentlySelectedNode() == palette.HConnector.Element);
        }
        
        [Test]
        public void NodesPalette_SelectLConnector_NodeIsSelected()
        {
            var palette = NodesPaletteUtils.CreatePalette();
            
            palette.LConnector.Button.onClick.Invoke();
            
            Assert.IsTrue(palette.Palette.CurrentlySelectedNode() == palette.LConnector.Element);
        }
        
        [Test]
        public void NodesPalette_SelectLConnectorFromHConnector_NodeIsSelected()
        {
            var palette = NodesPaletteUtils.CreatePalette();
            
            palette.HConnector.Button.onClick.Invoke();
            palette.LConnector.Button.onClick.Invoke();
            
            Assert.IsTrue(palette.Palette.CurrentlySelectedNode() == palette.LConnector.Element);
        }
        
        [Test]
        public void NodesPalette_DeselectHConnector_NodeIsNull()
        {
            var palette = NodesPaletteUtils.CreatePalette();
            
            palette.HConnector.Button.onClick.Invoke();
            palette.HConnector.Button.onClick.Invoke();
            
            Assert.IsNull(palette.Palette.CurrentlySelectedNode());
        }
        
        [Test]
        public void NodesPalette_RotateSelectedConnectorOnce_ConnectorRotated()
        {
            var palette = NodesPaletteUtils.CreatePalette();
            
            palette.HConnector.Button.onClick.Invoke();
            palette.LConnector.Button.onClick.Invoke();
            palette.InputProviderStub.InvokeRKeyPressed();
            
            Assert.True(Mathf.Approximately(palette.LConnector.Value.transform.eulerAngles.z, 90), "LConnector wasn't rotated");
            Assert.True(Mathf.Approximately(palette.HConnector.Value.transform.eulerAngles.z, 0), "HConnector was rotated");
        }
    }
}