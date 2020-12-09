using Entitas;
using UnityEngine;

public class DelayedSystem : ICleanupSystem
{
    private Contexts _contexts;
    
    public DelayedSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Cleanup()
    {
        var entities = _contexts.game.GetEntities(GameMatcher.AllOf(
            GameMatcher.DoubleFirePowerup, GameMatcher.Delayed));

        for (int i = 0; i < entities.Length; i++)
        {
            var entity = entities[i];
            if (entity.hasDelayed && entity.hasDoubleFirePowerup)
            {
                if (entity.delayed.finishTime <= Time.time)
                {
                    entity.RemoveDelayed();
                }    
            }
        }
    }
}