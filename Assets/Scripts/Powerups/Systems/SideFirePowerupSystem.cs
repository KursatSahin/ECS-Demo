using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class SideFirePowerupSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public SideFirePowerupSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ShootingTrigger.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasShootingTrigger && entity.hasSideFirePowerup;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var playerTransform = entity.view.value;
            TankFields data = playerTransform.GetComponent<TankFields>();
        
            var leftSideFireSpawnPoint = data.m_LeftFireTransform.position;
            var leftSideFireRotation = data.m_LeftFireTransform.up;
        
            var rightSideFireSpawnPoint = data.m_RightFireTransform.position;
            var rightSideFireRotation = data.m_RightFireTransform.up;
        
            // Left Side Shoot
            Shoot(leftSideFireSpawnPoint, leftSideFireRotation, entity.shootingPreferences);
            // Right Side Shoot
            Shoot(rightSideFireSpawnPoint, rightSideFireRotation, entity.shootingPreferences);    
        }
    }

    private void Shoot(Vector3 position, Vector3 rotation, ShootingPreferencesComponent shootingPreferences)
    {
        var entity = _contexts.game.CreateEntity();
        entity.isShell = true;
                
        var gameConstants = _contexts.game.gameConstants.value;
                
        entity.AddPrefab(gameConstants.projectilePrefab);

        entity.AddPosition(position);
        entity.AddAcceleration(rotation * shootingPreferences.shootingSpeed);
    }
}