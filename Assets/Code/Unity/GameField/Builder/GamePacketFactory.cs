using Code.Application.Ports;
using Code.Domain;
using NaughtyAttributes;
using UnityEngine;

namespace Code.Unity.GameField.Builder
{
    public class GamePacketFactory: MonoBehaviour, IGamePacketFactory
    {
        [SerializeField, Required] private RectTransform _root = null!;
        [SerializeField, Required] private PacketDisplay _packet = null!;
        
        public PacketDisplay Create(Position at)
        {
            var instantiatedNode = Instantiate(_packet, _root);
            instantiatedNode.transform.localPosition = new Vector3(at.X * GlobalData.CellSize, at.Y * GlobalData.CellSize, _root.transform.localPosition.z);
            return instantiatedNode;
        }
    }
}