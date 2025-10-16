using UnityEngine;

namespace Code.Application.Ports
{
    public interface IGameFieldNodeBuilder
    {
        GameObject Build(Vector2Int at, GameObject node);
    }
}