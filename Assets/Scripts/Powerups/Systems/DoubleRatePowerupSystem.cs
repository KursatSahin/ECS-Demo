using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class DoubleRatePowerupSystem : ReactiveSystem<GameEntity>
{
	private Contexts _contexts;
    
	public DoubleRatePowerupSystem(Contexts contexts) : base(contexts.game) {
		_contexts = contexts;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.DoubleRatePowerup.AddedOrRemoved());
	}

	protected override bool Filter(GameEntity entity)
	{
		return true;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var entity in entities)
		{
			if (!entity.hasShootingPreferences)
			{
				Debug.Log("Missing Component!! Each player entity must have ShootingPreferencesComponent");
				return;
			}
			else
			{
				if (entity.hasDoubleRatePowerup)
				{
					entity.shootingPreferences.shootingRate = _contexts.game.gameConstants.value.fireRate * .5f;
				}
				else
				{
					entity.shootingPreferences.shootingRate = _contexts.game.gameConstants.value.fireRate;
				}
			}
		}
	}
}
