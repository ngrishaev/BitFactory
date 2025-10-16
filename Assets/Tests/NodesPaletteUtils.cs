using System;
using Code.Unity.GameField.Palette;
using Code.Unity.Services;
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

            var userInputProviderStub = new UserInputProviderStub();
            holder.Construct(userInputProviderStub);
            
            return new NodesPaletteTestWrapper(
                palette: holder,
                lConnector: lConnector,
                hConnector: hConnector,
                inputProviderStub: userInputProviderStub);
        }

        public class UserInputProviderStub : IUserInputProvider
        {
            public event Action? OnRKeyPressed;
            
            public void InvokeRKeyPressed()
            {
                OnRKeyPressed?.Invoke();
            }

            public Vector3 MousePosition()
            {
                return Vector3.zero;
            }
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
            
            var iconGo = new GameObject();
            iconGo.transform.SetParent(mainGo.transform);
            PrivateField.Set(paletteElement, "_icon", iconGo);

            paletteElement.Construct();
            return new NodesPaletteElementTestWrapper(
                mainGo: mainGo,
                element: paletteElement,
                button: button,
                highlight: highlightGo,
                value: iconGo);
        }

        public class NodesPaletteElementTestWrapper
        {
            public readonly GameObject MainGo;
            public readonly NodesPaletteElement Element;
            public readonly Button Button;
            public readonly GameObject Highlight;
            public readonly GameObject Value;

            public NodesPaletteElementTestWrapper(GameObject mainGo, NodesPaletteElement element, Button button, GameObject highlight, GameObject value)
            {
                MainGo = mainGo;
                Element = element;
                Button = button;
                Highlight = highlight;
                Value = value;
            }
        }
        
        public class NodesPaletteTestWrapper
        {
            public NodesPalette Palette;
            public NodesPaletteElementTestWrapper LConnector;
            public NodesPaletteElementTestWrapper HConnector;
            public UserInputProviderStub InputProviderStub;

            public NodesPaletteTestWrapper(NodesPalette palette, NodesPaletteElementTestWrapper lConnector, NodesPaletteElementTestWrapper hConnector, UserInputProviderStub inputProviderStub)
            {
                Palette = palette;
                LConnector = lConnector;
                HConnector = hConnector;
                InputProviderStub = inputProviderStub;
            }
        }
    }
}