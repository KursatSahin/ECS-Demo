using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class DoubleFireShootingTriggerSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    private const float doubleFireDelay = .1f;
        
    public DoubleFireShootingTriggerSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }
        
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Timer.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasTimer && entity.hasDoubleFireShootingTrigger && entity.hasShootingPreferences;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var modDivider =
                entity.shootingPreferences.shootingRate +
                (entity.shootingPreferences.shootingRate * entity.doubleFireShootingTrigger.value) +
                doubleFireDelay;
                ;
            
            if (entity.timer.currentTime % modDivider <= .1f)
            {
                entity.ReplaceDoubleFireShootingTrigger(entity.doubleFireShootingTrigger.value + 1);
            }
        }
    }
        
}