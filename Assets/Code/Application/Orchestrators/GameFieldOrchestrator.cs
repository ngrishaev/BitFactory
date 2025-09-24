using Code.Application.Ports;
using UnityEngine;

namespace Code.Application.Orchestrators
{
    public class GameFieldOrchestrator
    {
        private readonly IGameFieldBuild _gameFieldBuild;
        private readonly IGameFieldPalette _gameFieldPalette;

        public GameFieldOrchestrator(
            IGameFieldInput gameFieldInput,
            IGameFieldBuild gameFieldBuild,
            IGameFieldPalette gameFieldPalette)
        {
            _gameFieldBuild = gameFieldBuild;
            _gameFieldPalette = gameFieldPalette;
            gameFieldInput.OnCellClicked += CellClicked;
        }

        private void CellClicked(Vector2Int cellPosition)
        {
            if(_gameFieldPalette.CurrentlySelectedNode() is null)
                return;
            
            // TODO: `CurrentlySelectedNode().gameObject` - NOPE
            _gameFieldBuild.Build(cellPosition, _gameFieldPalette.CurrentlySelectedNode().gameObject);
        }
    }
}