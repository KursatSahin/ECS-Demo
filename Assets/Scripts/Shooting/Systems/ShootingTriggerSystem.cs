using System.Collections.Generic;
using Entitas;


public class ShootingTriggerSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
        
    public ShootingTriggerSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }
        
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Timer.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasTimer && entity.hasShootingTrigger && entity.hasShootingPreferences;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var modDivider = entity.shootingPreferences.shootingRate +
                             (entity.shootingPreferences.shootingRate * entity.shootingTrigger.value);
            
            if (entity.timer.currentTime % modDivider <= .1f)
            {
                entity.ReplaceShootingTrigger(entity.shootingTrigger.value + 1);
            }
        }
    }
}