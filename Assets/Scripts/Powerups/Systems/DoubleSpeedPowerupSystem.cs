using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class DoubleSpeedPowerupSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    
    public DoubleSpeedPowerupSystem(Contexts contexts) : base(contexts.game) {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.DoubleSpeedPowerup.AddedOrRemoved());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasShootingPreferences;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var playerEntity = _contexts.game.GetGroup(GameMatcher.Player).GetSingleEntity();

        if (playerEntity.hasDoubleSpeedPowerup)
        {
            playerEntity.shootingPreferences.shootingSpeed = _contexts.game.gameConstants.value.fireSpeed * 2f;
        }
        else
        {
            playerEntity.shootingPreferences.shootingSpeed = _contexts.game.gameConstants.value.fireSpeed;
        }
    }
}
