using Code.Unity.GameField.Builder;
using UnityEngine;

namespace Code.Application.Ports
{
    public interface IGamePacketFactory
    {
        PacketDisplay Create(Vector2Int at);
    }
}