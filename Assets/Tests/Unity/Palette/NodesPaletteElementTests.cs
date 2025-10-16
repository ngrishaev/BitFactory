using Code.Unity.GameField.Palette;
using NUnit.Framework;
using UnityEngine;

namespace Tests.Unity.Palette
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
        
        [Test]
        public void SelectableNode_Rotate1Times_ElementRotated90Degree()
        {
            var elementHolder = NodesPaletteUtils.CreatePaletteElement();
            
            elementHolder.Element.Rotate();
            
            Assert.True(Mathf.Approximately(elementHolder.Value.transform.rotation.eulerAngles.z, 270));
        }
        
        [Test]
        public void SelectableNode_Rotate2Times_ElementRotated180Degree()
        {
            var elementHolder = NodesPaletteUtils.CreatePaletteElement();
            
            elementHolder.Element.Rotate();
            elementHolder.Element.Rotate();
            
            // TODO: Refactor rotation with enum
            Assert.True(Mathf.Approximately(elementHolder.Value.transform.rotation.eulerAngles.z, 180));
        }
        
        [Test]
        public void SelectableNode_Rotate3Times_ElementRotated270Degree()
        {
            var elementHolder = NodesPaletteUtils.CreatePaletteElement();
            
            elementHolder.Element.Rotate();
            elementHolder.Element.Rotate();
            elementHolder.Element.Rotate();
            
            Assert.True(Mathf.Approximately(elementHolder.Value.transform.rotation.eulerAngles.z, 90));
        }
        
        [Test]
        public void SelectableNode_Rotate4Times_ElementRotated0Degree()
        {
            var elementHolder = NodesPaletteUtils.CreatePaletteElement();
            
            elementHolder.Element.Rotate();
            elementHolder.Element.Rotate();
            elementHolder.Element.Rotate();
            elementHolder.Element.Rotate();
            
            Assert.True(Mathf.Approximately(elementHolder.Value.transform.rotation.eulerAngles.z, 0));
        }
        
        [Test]
        public void SelectableNode_Rotate5Times_ElementRotated90Degree()
        {
            var elementHolder = NodesPaletteUtils.CreatePaletteElement();
            
            elementHolder.Element.Rotate();
            elementHolder.Element.Rotate();
            elementHolder.Element.Rotate();
            elementHolder.Element.Rotate();
            elementHolder.Element.Rotate();
            
            Assert.True(Mathf.Approximately(elementHolder.Value.transform.rotation.eulerAngles.z, 270));
        }
        
        [Test]
        public void SelectableNode_RotateAndReset_ElementRotated0Degree()
        {
            var elementHolder = NodesPaletteUtils.CreatePaletteElement();
            
            elementHolder.Element.Rotate();
            elementHolder.Element.ResetRotation();
            
            Assert.True(Mathf.Approximately(elementHolder.Value.transform.rotation.eulerAngles.z, 0));
        }
    }
}
