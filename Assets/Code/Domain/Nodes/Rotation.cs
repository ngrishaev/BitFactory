namespace Code.Domain.Nodes
{
    public enum Rotation
    {
        Clockwise0,
        Clockwise90,
        Clockwise180,
        Clockwise270
    }

    public static class RotationExtensions
    {
        public static int ToDegree(this Rotation rotation)
        {
            return rotation switch
            {
                Rotation.Clockwise0 => 0,
                Rotation.Clockwise90 => 90,
                Rotation.Clockwise180 => 180,
                Rotation.Clockwise270 => 270,
                _ => throw new System.ArgumentOutOfRangeException(nameof(rotation))
            };
        }
    }
}