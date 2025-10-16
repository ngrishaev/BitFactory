using Code.Domain.Nodes;

namespace Code.Domain
{
    public class GameField: IField
    {
        private readonly FieldNode[,] _field;
        
        public GameField(int width, int height)
        {
            _field = new FieldNode[width,height];
        }

        public void SetNode(int x, int y, FieldNode node)
        {
            _field[x, y] ??= node;
        }

        public FieldNode GetAt(int x, int y)
        {
            return _field[x, y];
        }
        
        public bool Occupied(int x, int y)
        {
            return _field[x, y] != null;
        }

        public FieldNode GetNodeAt(int posX, int posY)
        {
            if (posX >= _field.GetLength(0) || posY >= _field.GetLength(1) || posX < 0 || posY < 0)
                return null;
            
            return _field[posX, posY];
        }
    }
}