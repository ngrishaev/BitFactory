using Code.Application.Ports;
using Code.Domain;
using Code.Domain.Nodes;
using Code.Unity.GameField.Palette;
using UnityEngine;

namespace Code.Application.Orchestrators
{
    public class GameFieldOrchestrator
    {
        private readonly GameField _gameField;
        private readonly IGameFieldNodeBuilder _gameFieldNodeBuilder;
        private readonly IGameFieldPalette _gameFieldPalette;

        public GameFieldOrchestrator(
            GameField gameField,
            IGameFieldInput gameFieldInput,
            IGameFieldNodeBuilder gameFieldNodeBuilder,
            IGameFieldPalette gameFieldPalette)
        {
            _gameField = gameField;
            _gameFieldNodeBuilder = gameFieldNodeBuilder;
            _gameFieldPalette = gameFieldPalette;
            gameFieldInput.OnCellClicked += CellClicked;
        }

        private void CellClicked(Vector2Int cellPosition)
        {
            var currentNode = _gameFieldPalette.CurrentlySelectedNode();
            if(currentNode is null)
                return;
            
            if (_gameField.Occupied(cellPosition.x, cellPosition.y))
                return;
            
            var fieldNode = CreateNodeFromEnum(currentNode);
            if (fieldNode == null)
            {
                Debug.LogError("Cannot find node for the selected palette element: " + currentNode.NodeType());
                return;
            }
            _gameField.SetNode(cellPosition.x, cellPosition.y, fieldNode);
            // TODO: `someNode.gameObject` - NOPE
            _gameFieldNodeBuilder.Build(cellPosition, currentNode.gameObject);
        }

        private static FieldNode? CreateNodeFromEnum(NodesPaletteElement currentNode)
        {
            return currentNode.NodeType() switch
            {
                NodeType.ConnectorHorizontal => new ConnectorH(currentNode.Rotation()),
                NodeType.ConnectorL => new ConnectorL(currentNode.Rotation()),
                _ => null
            };
        }
    }
}