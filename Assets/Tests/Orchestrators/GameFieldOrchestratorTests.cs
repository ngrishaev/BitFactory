using System;
using System.Collections.Generic;
using Code.Application.Orchestrators;
using Code.Application.Ports;
using Code.Domain;
using Code.Unity.GameField.Nodes;
using Code.Unity.GameField.Palette;
using NUnit.Framework;
using UnityEngine;

namespace Tests.Orchestrators
{
    [TestFixture]
    public class GameFieldOrchestratorTests
    {
        [Test]
        public void GameFieldOrchestrator_UserBuildsNode()
        {
            var gameFieldInput = new GameFieldInputStub();
            var gameFieldBuild = new GameFieldNodeBuilderStub();
            var gameFieldPalette = new GameFieldPaletteStub();
            _ = new GameFieldOrchestrator(new GameField(8, 8), gameFieldInput, gameFieldBuild, gameFieldPalette);
            
            gameFieldPalette.SelectSomeNode();
            gameFieldInput.ClickAt(new Vector2Int(2,3));
            
            Assert.IsTrue(gameFieldBuild.WasNodeBuiltAt(new Position(2,3)));
        }
        
        [Test]
        public void GameFieldOrchestrator_NoNodeSelected_NoBuild()
        {
            var gameFieldInput = new GameFieldInputStub();
            var gameFieldBuild = new GameFieldNodeBuilderStub();
            var gameFieldPalette = new GameFieldPaletteStub();
            _ = new GameFieldOrchestrator(new GameField(8, 8), gameFieldInput, gameFieldBuild, gameFieldPalette);

            gameFieldInput.ClickAt(new Vector2Int(1,1));

            Assert.IsFalse(gameFieldBuild.WasNodeBuiltAt(new Position(1,1)));
        }

        [Test]
        public void GameFieldOrchestrator_MultipleClicks_BuildsEverywhere()
        {
            var gameFieldInput = new GameFieldInputStub();
            var gameFieldBuild = new GameFieldNodeBuilderStub();
            var gameFieldPalette = new GameFieldPaletteStub();
            _ = new GameFieldOrchestrator(new GameField(8, 8), gameFieldInput, gameFieldBuild, gameFieldPalette);

            gameFieldPalette.SelectSomeNode();
            gameFieldInput.ClickAt(new Vector2Int(0,0));
            gameFieldInput.ClickAt(new Vector2Int(4,5));

            Assert.IsTrue(gameFieldBuild.WasNodeBuiltAt(new Position(0,0)));
            Assert.IsTrue(gameFieldBuild.WasNodeBuiltAt(new Position(4,5)));
        }
        
        [Test]
        public void GameFieldOrchestrator_CantBuildOnOccupiedPlace()
        {
            var gameFieldInput = new GameFieldInputStub();
            var gameFieldBuild = new GameFieldNodeBuilderStub();
            var gameFieldPalette = new GameFieldPaletteStub();
            _ = new GameFieldOrchestrator(new GameField(8, 8), gameFieldInput, gameFieldBuild, gameFieldPalette);

            gameFieldPalette.SelectSomeNode();
            gameFieldInput.ClickAt(new Vector2Int(4, 5));
            gameFieldInput.ClickAt(new Vector2Int(4, 5));
            
            Assert.True(gameFieldBuild.TotalNodesBuilt() == 1, "Expected only one node to be built, but found: " + gameFieldBuild.TotalNodesBuilt());
        }
        
    }

    public class GameFieldPaletteStub : IGameFieldPalette
    {
        private NodesPaletteElement? _selectedNode;
        
        public void SelectSomeNode()
        {
            _selectedNode = NodesPaletteUtils.CreatePaletteElement().Element;
        }

        public NodesPaletteElement? CurrentlySelected()
        {
            return _selectedNode;
        }
    }

    public class GameFieldNodeBuilderStub : IGameFieldNodeBuilder
    {
        private List<Position> _builds = new List<Position>();
        
        public bool WasNodeBuiltAt(Position position)
        {
            return _builds.Contains(position);
        }

        public int TotalNodesBuilt()
        {
            return _builds.Count;
        }

        public TNodeType Build<TNodeType>(Position at, TNodeType node) where TNodeType : NodeDisplay
        {
            _builds.Add(at);
            return node;
        }
    }

    public class GameFieldInputStub : IGameFieldInput
    {
        public event Action<Vector2Int>? OnCellClicked;
        public event Action? OnNextTickClicked;

        public void ClickAt(Vector2Int vector2Int)
        {
            OnCellClicked?.Invoke(vector2Int);
        }
    }
}