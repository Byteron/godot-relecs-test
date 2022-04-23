using Godot;

namespace RelEcs.Godot
{
    public class Time { public float Delta; }

    public interface IRunSystem : ISystem { }

    public interface IInitSystem : ISystem { }

    public interface IDeinitSystem : ISystem { }

    public struct Node<T> where T : Node
    {
        public T Value;
        public Node(T node) => Value = node;
    }

    public class Marshallable<T> : Reference { public T Object { get; set; } }
}