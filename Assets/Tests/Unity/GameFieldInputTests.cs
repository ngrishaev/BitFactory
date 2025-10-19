using System;
using Code.Unity;
using Code.Unity.GameField.Input;
using Code.Unity.Services;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace Tests.Unity
{
    [TestFixture]
    public class GameFieldInputTests
    {
        [Test]
        public void GameFieldInputStub_ClickOnFirstCell()
        {
            var gameFieldInputWrapper = CreateGameFieldInput();
            
            gameFieldInputWrapper.UserInputProviderStub.SetupMousePosition(new Vector3(50, 50));
            
            var clickedPosition = new Vector2Int(-1, -1);
            gameFieldInputWrapper.GameFieldInput.OnCellClicked += (cellPos) => clickedPosition = cellPos;
            gameFieldInputWrapper.GameFieldInputButton.onClick.Invoke();
            
            Assert.AreEqual(new Vector2Int(0, 0), clickedPosition);
        }
        
        [Test]
        public void GameFieldInputStub_ClickOn2x1Cell()
        {
            var gameFieldInputWrapper = CreateGameFieldInput();
            gameFieldInputWrapper.UserInputProviderStub.SetupMousePosition(
                new Vector3(
                    GlobalData.CellSize * 3 - GlobalData.CellSize / 2,
                    GlobalData.CellSize * 2 - GlobalData.CellSize / 2));
            
            var clickedPosition = new Vector2Int(-1, -1);
            gameFieldInputWrapper.GameFieldInput.OnCellClicked += cellPos => clickedPosition = cellPos;
            gameFieldInputWrapper.GameFieldInputButton.onClick.Invoke();
            
            Assert.AreEqual(new Vector2Int(2, 1), clickedPosition);
        }
        

        private static GameFieldInputTestWrapper CreateGameFieldInput()
        {
            var gameFieldInputGo = new GameObject();
            var gameFieldRect = gameFieldInputGo.AddComponent<RectTransform>();
            var gameFieldInput = gameFieldInputGo.AddComponent<GameFieldCellsInput>();
            var buttonsHolder = new GameObject("ButtonsHolder");
            buttonsHolder.transform.SetParent(gameFieldInputGo.transform, false);
            
            var gameFieldInputButton = MakeButton("Input Button");
            var gameFieldTickButton = MakeButton("Tick Button");
            
            gameFieldRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 800f);
            gameFieldRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 800f);
            
            PrivateField.Set(gameFieldInput, "_root", gameFieldRect);
            PrivateField.Set(gameFieldInput, "_gameFieldGlobalButton", gameFieldInputButton);
            PrivateField.Set(gameFieldInput, "_tickButton", gameFieldTickButton);
            
            var inputProviderStub = new UserInputProviderStub();
            gameFieldInput.Construct(inputProviderStub);

            return new GameFieldInputTestWrapper(
                gameFieldInput: gameFieldInput,
                userInputProviderStub: inputProviderStub,
                gameFieldInputButton: gameFieldInputButton);

            Button MakeButton(string buttonName)
            {
                var inputButtonGo = new GameObject(buttonName);
                inputButtonGo.transform.SetParent(buttonsHolder.transform, false);
                return inputButtonGo.AddComponent<Button>();
            }
        }

        private sealed record GameFieldInputTestWrapper
        {
            public readonly GameFieldCellsInput GameFieldInput;
            public readonly UserInputProviderStub UserInputProviderStub;
            public readonly Button GameFieldInputButton;

            public GameFieldInputTestWrapper(GameFieldCellsInput gameFieldInput, UserInputProviderStub userInputProviderStub, Button gameFieldInputButton)
            {
                GameFieldInput = gameFieldInput;
                UserInputProviderStub = userInputProviderStub;
                GameFieldInputButton = gameFieldInputButton;
            }
        }

        private class UserInputProviderStub : IUserInputProvider
        {
            private Vector3 _mousePosition;
            
            public event Action? OnRKeyPressed;

            public void SetupMousePosition(Vector3 position)
            {
                _mousePosition = position;
            }

            public Vector3 MousePosition()
            {
                return _mousePosition;
            }
        }
    }
}