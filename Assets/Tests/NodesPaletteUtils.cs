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
            
            return new NodesPaletteTestWrapper
            {
                Palette = holder,
                LConnector = lConnector,
                HConnector = hConnector,
                InputProviderStub = userInputProviderStub
            };
        }

        public class UserInputProviderStub : IUserInputProvider
        {
            public event Action OnRKeyPressed;
            
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
            return new NodesPaletteElementTestWrapper
            {
                MainGo = mainGo,
                Element = paletteElement,
                Button = button,
                Highlight = highlightGo,
                Value = iconGo
            };
        }

        public class NodesPaletteElementTestWrapper
        {
            public GameObject MainGo;
            public NodesPaletteElement Element;
            public Button Button;
            public GameObject Highlight;
            public GameObject Value;
        }
        
        public class NodesPaletteTestWrapper
        {
            public NodesPalette Palette;
            public NodesPaletteElementTestWrapper LConnector;
            public NodesPaletteElementTestWrapper HConnector;
            public UserInputProviderStub InputProviderStub { get; set; }
        }
    }
}