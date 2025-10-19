using System.Collections.Generic;
using Code.Application.Orchestrators;
using Code.Domain;
using Code.Unity.GameField.Builder;
using Code.Unity.GameField.Input;
using Code.Unity.GameField.Palette;
using NaughtyAttributes;
using UnityEngine;
// ReSharper disable NotAccessedField.Local

namespace Code.Unity
{
    public class GameRoot: MonoBehaviour
    {
        [SerializeField, Required] private NodesPalette _palette = null!;
        [SerializeField, Required] private NodeBuilder _builder = null!;
        [SerializeField, Required] private GameFieldCellsInput _input = null!;
        private GameFieldOrchestrator? _gameFieldOrchestrator;
        private PackageOrchestrator? _packageOrchestrator;

        private void Start()
        {
            var gameField = new Domain.GameField(8, 8); // TODO: hardcode = bad

            _gameFieldOrchestrator = new GameFieldOrchestrator(gameField, _input, _builder, _palette);
            var spawners = new HashSet<Spawner>();
            spawners.Add(new Spawner(gameField));
            _packageOrchestrator = new PackageOrchestrator(spawners, _input);
        }
    }
}