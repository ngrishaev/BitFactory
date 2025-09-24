using Code.Unity.Palette;
using UnityEngine;

namespace Code.Application.Ports
{
    public interface IGameFieldPalette
    {
        NodesPaletteElement CurrentlySelectedNode();
    }
}