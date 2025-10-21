using Code.Application.Common;
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
            var paletteElement = _gameFieldPalette.CurrentlySelected();
            if(paletteElement is null)
                return;
            
            if (_gameField.Occupied(cellPosition.ToPosition()))
                return;
            
            var fieldNode = CreateNodeFromEnum(paletteElement, cellPosition.ToPosition());
            if (fieldNode == null)
            {
                Debug.LogError("Cannot find node for the selected palette element: " + paletteElement.NodeType());
                return;
            }
            _gameField.SetNode(cellPosition.ToPosition(), fieldNode);
            // TODO: `someNode.gameObject` - NOPE
            _gameFieldNodeBuilder.Build(cellPosition.ToPosition(), paletteElement.Node, paletteElement.Rotation());
        }

        private static FieldNode? CreateNodeFromEnum(NodesPaletteElement currentNode, Position position)
        {
            return currentNode.NodeType() switch
            {
                NodeType.ConnectorHorizontal => new ConnectorH(currentNode.Rotation(), position),
                NodeType.ConnectorL => new ConnectorL(currentNode.Rotation(), position),
                _ => null
            };
        }
    }
}