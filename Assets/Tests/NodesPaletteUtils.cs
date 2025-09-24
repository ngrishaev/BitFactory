using Code.Unity;
using Code.Unity.GameField.Palette;
using UnityEngine;
using UnityEngine.UI;

namespace Tests
{
    public static class NodesPaletteUtils
    {
        public static NodesPaletteTestWrapper CreatePalette()
        {
            var holderGo = new GameObject();
            var lConnector = CreatePaletteElement();
            var hConnector = CreatePaletteElement();
            
            lConnector.MainGo.transform.SetParent(holderGo.transform);
            hConnector.MainGo.transform.SetParent(holderGo.transform);
            
            var holder = holderGo.AddComponent<NodesPalette>();
            
            PrivateField.Set(holder, "_lConnector", lConnector.Element);
            PrivateField.Set(holder, "_horizontalConnector", hConnector.Element);
            
            holder.Construct();
            
            return new NodesPaletteTestWrapper
            {
                Palette = holder,
                LConnector = lConnector,
                HConnector = hConnector
            };
        }

        public static NodesPaletteElementTestWrapper CreatePaletteElement()
        {
            var mainGo = new GameObject();
            var paletteElement = mainGo.AddComponent<NodesPaletteElement>();
            
            var button = mainGo.AddComponent<Button>();
            PrivateField.Set(paletteElement, "_button", button);
            
            var highlightGo = new GameObject();
            highlightGo.transform.SetParent(mainGo.transform);
            PrivateField.Set(paletteElement, "_highlight", highlightGo);
            
            paletteElement.Construct();
            return new NodesPaletteElementTestWrapper
            {
                MainGo = mainGo,
                Element = paletteElement,
                Button = button,
                Highlight = highlightGo
            };
        }

        public class NodesPaletteElementTestWrapper
        {
            public GameObject MainGo;
            public NodesPaletteElement Element;
            public Button Button;
            public GameObject Highlight;
        }
        
        public class NodesPaletteTestWrapper
        {
            public NodesPalette Palette;
            public NodesPaletteElementTestWrapper LConnector;
            public NodesPaletteElementTestWrapper HConnector;
        }
    }
}