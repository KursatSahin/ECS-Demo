using System.Collections.Generic;
using Entitas;

public class ShootingSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    public ShootingSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(
            GameMatcher.ShootingTrigger.Added(), 
            GameMatcher.Delayed.Removed());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasShootingTrigger;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            Shoot(entity);
        }
    }

    private void Shoot(GameEntity entity)
    {
        var shellEntity = _contexts.game.CreateEntity();
        shellEntity.isShell = true;
            
        var gameConstants = _contexts.game.gameConstants.value;
        var shootingPreferences = entity.shootingPreferences; 
            
        shellEntity.AddPrefab(gameConstants.projectilePrefab);

        var playerTransform = entity.view.value.transform;
        var playerForward = playerTransform.up;
            
        shellEntity.AddAcceleration(playerForward * shootingPreferences.shootingSpeed);
        shellEntity.AddPosition(playerTransform.GetComponent<TankFields>().m_FireTransform.position);
    }
}