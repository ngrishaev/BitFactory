using System.Collections.Generic;
using Code.Domain.Nodes;

namespace Code.Domain
{
    public interface IGameEvent { }

    public class SpawnPacketEvent : IGameEvent
    {
        public readonly Spawner Spawner;
        public readonly FieldNode Node;

        public SpawnPacketEvent(Spawner spawner, FieldNode node)
        {
            Spawner = spawner;
            Node = node;
        }
    }

    public class PlannedTicks : HashSet<IGameEvent>
    {
        
    }
    
    public class Spawner
    {
        public static Position DefaultPosition => new Position(-1, 7);
        
        public Position Position { get; private set; }
        public PlannedTicks Ticks  = new ();
        
        private readonly IField _field;
        
        public Spawner(IField field, Position position)
        {
            _field = field;
            Position = position;
        }

        public void PlanTick()
        {
            Ticks.Clear();
            // TODO: this is a hardcoded position.
            // TODO: make position as separate class
            // TODO: make spawner position configurable
            var node = _field.GetNodeAt(Position.Right());

            // TODO: this is a hardcoded side. Should be calculatable
            if (node?.CanAcceptPacketFrom(NodeSide.Left) ?? false)
            {
                Ticks.Add(new SpawnPacketEvent(this, node));
            }
            
            //node?.TryAcceptPacketFrom(NodeSide.Left, new FieldPacket());
        }

        public void ImplementPlannedTick()
        {
            foreach (var @event in Ticks)
            {
                switch (@event)
                {
                    case SpawnPacketEvent spawnPacketEvent:
                        spawnPacketEvent.Node.TryAcceptPacketFrom(NodeSide.Left, new FieldPacket());
                        break;
                }
            }
        }
    }

    public interface IField
    {
        FieldNode? GetNodeAt(Position position);
    }
}