using System;
using Code.Domain;

namespace Code.Application.Ports
{
    public interface IGameFieldInput
    {
        event Action<Position> OnCellClicked;
        event Action OnNextTickClicked;
    }
}