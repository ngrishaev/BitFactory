using System.Collections.Generic;
using Code.Application.Ports;
using Code.Domain;
using Code.Unity.GameField.Nodes;
using Code.Unity.Swapner;

namespace Code.Application.Orchestrators
{
    public class TickOrchestrator
    {
        private readonly HashSet<Spawner> _spawners;
        private readonly IGameFieldInput _gameFieldInput;
        private readonly IGamePacketFactory _gamePacketFactory;
        private readonly INodesRegistry _nodesRegistryDisplay;

        public TickOrchestrator(
            HashSet<Spawner> spawners,
            IGameFieldInput gameFieldInput,
            IGamePacketFactory gamePacketFactory,
            INodesRegistry nodesRegistryDisplay
            )
        {
            _spawners = spawners;
            _gameFieldInput = gameFieldInput;
            _gamePacketFactory = gamePacketFactory;
            _nodesRegistryDisplay = nodesRegistryDisplay;

            _gameFieldInput.OnNextTickClicked += OnNextTickClicked;
        }

        private void OnNextTickClicked()
        {
            foreach (var spawner in _spawners)
            {
                spawner.PlanTick();
                spawner.ImplementPlannedTick();
                DisplayTicks(spawner.Ticks);
            }
        }

        private void DisplayTicks(PlannedTicks spawnerTicks)
        {
            foreach (var tick in spawnerTicks)
            {
                DisplayTick(tick);
            }
        }

        private void DisplayTick(IGameEvent tick)
        {
            switch (tick)
            {
                case SpawnPacketEvent spawnPacketEvent:
                    SpawnPacket(spawnPacketEvent);
                    break;
            }
        }

        private void SpawnPacket(SpawnPacketEvent spawnEvent)
        {
            var display = _gamePacketFactory.Create(spawnEvent.Spawner.Position);
            var spawner = _nodesRegistryDisplay.GetNodeAt<SpawnerDisplay>(spawnEvent.Spawner.Position);
            var node = _nodesRegistryDisplay.GetNodeAt<HorizontalConnector>(spawnEvent.Node.Position);
            spawner.Accept(display);
            spawner.PlayPass(display, node);
            node.PlayAccept(display);
        }
    }
}