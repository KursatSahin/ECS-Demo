using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class DoubleFirePowerupSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public DoubleFirePowerupSystem(Contexts contexts) : base(contexts.game) {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.DoubleFirePowerup.AddedOrRemoved());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasShootingTrigger;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.hasDoubleFirePowerup)
            {
                entity.AddDoubleFireShootingTrigger(entity.shootingTrigger.value);
            }
            else
            {
                entity.RemoveDoubleFireShootingTrigger();
            }
        }
    }
}