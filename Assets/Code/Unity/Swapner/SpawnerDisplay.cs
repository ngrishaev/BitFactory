using System;
using Code.Application.Ports;
using Code.Domain;
using Code.Unity.GameField.Builder;
using Code.Unity.GameField.Nodes;
using UnityEngine;

namespace Code.Unity.Swapner
{
    public class SpawnerDisplay : NodeDisplay
    {
        private Position _position = Spawner.DefaultPosition;

        public void Construct(INodesRegistry nodesRegistry)
        {
            nodesRegistry.Set(_position, this);
        }

        public void Accept(PacketDisplay display)
        {
            display.transform.SetParent(transform);
            display.transform.localPosition = Vector3.zero;
        }

        public void PlayPass(PacketDisplay display, HorizontalConnector node)
        {
        }
    }
}
