using UnityEngine;

namespace Code.Application.Ports
{
    public interface IGameFieldBuild
    {
        GameObject Build(Vector2Int at, GameObject node);
    }
}