using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Code.Application.Orchestrators;
using Code.Application.Ports;
using Code.Domain;
using Code.Unity.GameField.Builder;
using Code.Unity.GameField.Input;
using Code.Unity.GameField.Palette;
using Code.Unity.Services;
using Code.Unity.Swapner;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.TestTools;

// ReSharper disable NotAccessedField.Local
namespace Code.Unity
{ 
    [ExcludeFromCoverage]
    public class GameRoot: MonoBehaviour
    {
        [SerializeField, Required] private NodesPalette _palette = null!;
        [SerializeField, Required] private NodeBuilder _builder = null!;
        [SerializeField, Required] private GameFieldCellsInput _input = null!;
        [SerializeField, Required] private GamePacketFactory _packetFactory = null!;
        private GameFieldOrchestrator? _gameFieldOrchestrator;
        private TickOrchestrator? _packageOrchestrator;
        private NodesRegistry? _nodesRegistry;

        private void Start()
        {
            var gameField = new Domain.GameField(8, 8); // TODO: hardcode = bad
            _nodesRegistry = new NodesRegistry();

            // TODO: temporary hack, use DI later (and probablu spawn spawners anyway, probably shouldn't be in scene by default)
            var spawnerDisplays = FindObjectsByType<SpawnerDisplay>(FindObjectsSortMode.None);
            foreach (var spawnerDisplay in spawnerDisplays)
            {
                spawnerDisplay.Construct(_nodesRegistry);
            }

            _builder.Construct(_nodesRegistry);
            _gameFieldOrchestrator = new GameFieldOrchestrator(gameField, _input, _builder, _palette);
            var spawners = new HashSet<Spawner> { new Spawner(gameField, Spawner.DefaultPosition) };
            _packageOrchestrator = new TickOrchestrator(spawners, _input, _packetFactory, _nodesRegistry);
        }
    }
}