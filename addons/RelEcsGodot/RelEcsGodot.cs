using Godot;

namespace RelEcs.Godot
{
    public class Time { public float Delta; }

    public interface IRunSystem : ISystem { }

    public interface IInitSystem : ISystem { }

    public interface IDeinitSystem : ISystem { }

    // wraps a godot node into an ecs component
    public struct Node<T> where T : Node
    {
        public T Value;
        public Node(T value) => Value = value;
    }

    // wraps an ecs object into a godot variant
    public class Marshallable<T> : Reference
    {
        public T Value;
        public Marshallable(T value) => Value = value;
    }
}