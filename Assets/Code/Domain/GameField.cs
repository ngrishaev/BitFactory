using Code.Domain.Nodes;

namespace Code.Domain
{
    public class GameField: IField
    {
        private readonly FieldNodes _nodes;
        
        public GameField(int width, int height)
        {
            _nodes = new FieldNodes(width, height);
        }

        public void SetNode(Position position, FieldNode node)
        {
            _nodes[position] ??= node;
        }

        public FieldNode? GetAt(Position position)
        {
            return _nodes[position];
        }
        
        public bool Occupied(Position position)
        {
            return _nodes[position] != null;
        }

        public FieldNode? GetNodeAt(Position position)
        {
            if (position.X >= _nodes.GetLength(0) || position.Y >= _nodes.GetLength(1) || position.X < 0 || position.Y < 0)
                return null;
            
            return _nodes[position];
        }

        private class FieldNodes
        {
            private readonly FieldNode?[,] _nodes;

            public FieldNodes(int width, int height)
            {
                _nodes = new FieldNode[width,height];
            }
        
            public FieldNode? this[int x, int y]
            {
                get => _nodes[x, y];
                set => _nodes[x, y] = value;
            }

            public FieldNode? this[Position pos]
            {
                get => _nodes[pos.X, pos.Y];
                set => _nodes[pos.X, pos.Y] = value;
            }

            public int GetLength(int dimension)
            {
                return _nodes.GetLength(dimension);
            }
        }
    }
}