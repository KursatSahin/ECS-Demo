using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ShootingSystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _group;
    
    public ShootingSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        _group = _contexts.game.GetGroup(GameMatcher.AllOf(
            GameMatcher.ShootingTrigger));
        
        foreach (var entity in _group)
        {
            if ( entity.shootingTrigger.finishingTime <= Time.time )
            {
                Shoot(entity);
                entity.ReplaceShootingTrigger(Time.time + entity.shootingPreferences.shootingRate);
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