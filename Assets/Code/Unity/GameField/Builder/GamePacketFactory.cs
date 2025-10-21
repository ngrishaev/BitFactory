using Code.Application.Orchestrators;
using Code.Application.Ports;
using NaughtyAttributes;
using UnityEngine;

namespace Code.Unity.GameField.Builder
{
    public class GamePacketFactory: MonoBehaviour, IGamePacketFactory
    {
        [SerializeField, Required] private RectTransform _root = null!;
        [SerializeField, Required] private PacketDisplay _packet = null!;
        
        public PacketDisplay Create(Vector2Int at)
        {
            var instantiatedNode = Instantiate(_packet, _root);
            instantiatedNode.transform.localPosition = new Vector3(at.x * GlobalData.CellSize, at.y * GlobalData.CellSize, _root.transform.localPosition.z);
            return instantiatedNode;
        }
    }
}