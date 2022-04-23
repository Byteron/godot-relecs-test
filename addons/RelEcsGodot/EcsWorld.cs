using Godot;
using Godot.Collections;

namespace RelEcs.Godot
{
    public class EcsWorld : Node
    {
        World world = new World();

        SystemGroup initSystems = new SystemGroup();
        SystemGroup runSystems = new SystemGroup();
        SystemGroup deinitSystems = new SystemGroup();

        public override void _Ready()
        {
            Setup();
            initSystems.Run(world);
        }

        public override void _Process(float delta)
        {
            world.GetResource<Time>().Delta = delta;
            runSystems.Run(world);
        }

        public override void _ExitTree()
        {
            deinitSystems.Run(world);
        }

        private void Setup()
        {
            world.AddResource(new Time { Delta = 0f });

            PropagateCall("ConvertToEntity", new Array { new Marshallable<World> { Object = world } });

            foreach(var child in GetChildren())
            {
                if (child is IRunSystem runSystem)
                {
                    runSystems.Add(runSystem);
                }

                if (child is IInitSystem initSystem)
                {
                    initSystems.Add(initSystem);
                }

                if (child is IDeinitSystem deinitSystem)
                {
                    deinitSystems.Add(deinitSystem);
                }
            }
        }
    }
}
