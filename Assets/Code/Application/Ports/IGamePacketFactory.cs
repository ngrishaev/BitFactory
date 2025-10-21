using Code.Domain;
using Code.Unity.GameField.Builder;

namespace Code.Application.Ports
{
    public interface IGamePacketFactory
    {
        PacketDisplay Create(Position at);
    }
}