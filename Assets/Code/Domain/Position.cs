namespace Code.Domain
{
    public record Position
    {
        public readonly int X;
        public readonly int Y;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Position Up()
        {
            return new Position(X, Y + 1);
        }
        
        public Position Down()
        {
            return new Position(X, Y - 1);
        }
        
        public Position Left()
        {
            return new Position(X - 1, Y);
        }
        
        public Position Right()
        {
            return new Position(X + 1, Y);
        }
        
        public static Position Zero => new(0, 0);
        
        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}