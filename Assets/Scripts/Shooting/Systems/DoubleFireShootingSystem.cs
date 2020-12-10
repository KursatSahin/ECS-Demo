using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class DoubleFireShootingSystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _group;
    
    public DoubleFireShootingSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        var entities = _contexts.game.GetEntities(GameMatcher.AllOf(
            GameMatcher.DoubleFireShootingTrigger));

        for (int i = 0; i < entities.Length; i++)
        {
            var entity = entities[i];
            if ( entity.doubleFireShootingTrigger.finishingTime <= Time.time )
            {
                Shoot(entity);
                entity.RemoveDoubleFireShootingTrigger();    
            }
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
