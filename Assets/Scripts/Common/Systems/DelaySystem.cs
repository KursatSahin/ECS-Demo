using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class DelaySystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public DelaySystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Delay));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasDelay;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.AddDelayed(Time.time + entity.delay.duration);
            entity.RemoveDelay();
        }
    }
}