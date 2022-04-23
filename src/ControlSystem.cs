using Godot;
using System;
using RelEcs;
using RelEcs.Godot;

public class ControlSystem : Node, IRunSystem
{
    [Export] int speed = 200;

    public void Run(Commands commands)
    {
        var query = commands.Query().Has<Node<EcsEntity2D>>().Has<Node<Player>>();
        var time = commands.GetResource<Time>();

        query.ForEach((ref Node<EcsEntity2D> handle) =>
        {
            Vector2 direction = Vector2.Zero;

            direction.x = Input.GetAxis("ui_left", "ui_right");
            direction.y = Input.GetAxis("ui_up", "ui_down");

            handle.Value.Position += direction.Normalized() * speed * time.Delta;
        });
    }
}
