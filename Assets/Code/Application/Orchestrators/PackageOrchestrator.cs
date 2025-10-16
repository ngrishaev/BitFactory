using System.Collections.Generic;
using Code.Application.Ports;
using Code.Domain;
using UnityEngine;

namespace Code.Application.Orchestrators
{
    public class PackageOrchestrator
    {
        private readonly HashSet<Spawner> _spawners;
        private readonly IGameFieldInput _gameFieldInput;

        public PackageOrchestrator(HashSet<Spawner> spawners, IGameFieldInput gameFieldInput)
        {
            _spawners = spawners;
            _gameFieldInput = gameFieldInput;
            
            _gameFieldInput.OnNextTickClicked += OnNextTickClicked;
        }

        private void OnNextTickClicked()
        {
            foreach (var spawner in _spawners)
            {
                spawner.Tick();
            }

            Debug.Log("Tick processed");
        }
    }
}