using Code.Unity;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class NodesPaletteElementTests
    {
        [Test]
        public void PaletteElement_SendEvents()
        {
            var elementHolder = NodesPaletteUtils.CreatePaletteElement();

            NodesPaletteElement selectedNode = null;
            elementHolder.Element.OnClicked += (node) => { selectedNode = node; };
            elementHolder.Button.onClick.Invoke();
            
            Assert.True(selectedNode == elementHolder.Element);
        }

        [Test]
        public void PaletteElement_CanBeSelected()
        {
            var elementHolder = NodesPaletteUtils.CreatePaletteElement();
            
            elementHolder.Element.Select();
            
            Assert.True(elementHolder.Highlight.activeSelf);
        }
        
        [Test]
        public void SelectableNode_CanBeDeselected()
        {
            var elementHolder = NodesPaletteUtils.CreatePaletteElement();
            
            elementHolder.Element.Select();
            elementHolder.Element.Deselect();
            
            Assert.False(elementHolder.Highlight.activeSelf);
        }
        
        [Test]
        public void SelectableNode_DeselectedByDefault()
        {
            var elementHolder = NodesPaletteUtils.CreatePaletteElement();
            
            Assert.False(elementHolder.Highlight.activeSelf);
        }
    }
}
