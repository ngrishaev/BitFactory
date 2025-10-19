using Code.Unity.GameField.Palette;

namespace Code.Application.Ports
{
    public interface IGameFieldPalette
    {
        NodesPaletteElement? CurrentlySelectedNode();
    }
}