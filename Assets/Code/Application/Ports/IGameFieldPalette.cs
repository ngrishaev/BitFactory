using Code.Unity.GameField.Palette;
using UnityEngine;

namespace Code.Application.Ports
{
    public interface IGameFieldPalette
    {
        NodesPaletteElement CurrentlySelectedNode();
    }
}