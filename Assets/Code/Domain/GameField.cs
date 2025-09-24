namespace Code.Domain
{
    public class GameField
    {
        private FieldNode[,] _field;
        
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
    }
    
    public enum NodeType
    {
        ConnectorHorizontal,
        ConnectorL
    }
        
    public enum Rotation
    {
        None,
        Clockwise90,
        Clockwise180,
        Clockwise270
    }

    public class FieldNode
    {
        public NodeType Type;
        public Rotation Rotation;
    }
}