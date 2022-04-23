using Godot;

namespace RelEcs.Godot
{
    public class EcsEntity2D : Node2D
    {
        public Entity Entity;

        public void ConvertToEntity(Marshallable<World> world)
        {
            Entity = world.Value.Spawn().Add(new Node<EcsEntity2D>(this));

            foreach (var child in GetChildren())
            {
                if (child is EcsEntity2D)
                {
                    continue;
                }

                var addMethod = typeof(EcsEntity2D).GetMethod("AddNodeHandle");
                var addChildMethod = addMethod.MakeGenericMethod(new[] { child.GetType() });
                addChildMethod.Invoke(this, new object[] { child });
            }
        }

        public void AddNodeHandle<T>(T node) where T : Node
        {
            Entity.Add<Node<T>>(new Node<T>(node));
        }

        public override void _ExitTree()
        {
            Entity.Despawn();
        }
    }
}