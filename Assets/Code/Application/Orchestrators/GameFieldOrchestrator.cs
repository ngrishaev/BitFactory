using Code.Application.Ports;
using Code.Domain;
using UnityEngine;

namespace Code.Application.Orchestrators
{
    public class GameFieldOrchestrator
    {
        private readonly GameField _gameField;
        private readonly IGameFieldBuild _gameFieldBuild;
        private readonly IGameFieldPalette _gameFieldPalette;

        public GameFieldOrchestrator(
            GameField gameField,
            IGameFieldInput gameFieldInput,
            IGameFieldBuild gameFieldBuild,
            IGameFieldPalette gameFieldPalette)
        {
            _gameField = gameField;
            _gameFieldBuild = gameFieldBuild;
            _gameFieldPalette = gameFieldPalette;
            gameFieldInput.OnCellClicked += CellClicked;
        }

        private void CellClicked(Vector2Int cellPosition)
        {
            var currentNode = _gameFieldPalette.CurrentlySelectedNode();
            if(currentNode is null)
                return;
            
            if (_gameField.Occupied(cellPosition.x, cellPosition.y))
            {
                return;
            }
            
            var fieldNode = new FieldNode
            {
                Type = currentNode.NodeType(),
                Rotation = currentNode.Rotation()
            };
            _gameField.SetNode(cellPosition.x, cellPosition.y, fieldNode);
            // TODO: `CurrentlySelectedNode().gameObject` - NOPE
            _gameFieldBuild.Build(cellPosition, currentNode.gameObject);
        }
    }
}