using System;
using UnityEngine;

namespace Code.Application.Ports
{
    public interface IGameFieldInput
    {
        event Action<Vector2Int> OnCellClicked;
        event Action OnNextTickClicked;
    }
}