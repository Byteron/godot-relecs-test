using Godot;
using RelEcs;
using RelEcs.Godot;

public class PrintSystem : Node, IInitSystem
{
    public void Run(Commands commands)
    {
        GD.Print("Print System Run");

        commands.ForEach((ref Node<EcsEntity2D> entity2DHandle) =>
        {
            GD.Print(entity2DHandle.Value.Name);
        });
    }
}
