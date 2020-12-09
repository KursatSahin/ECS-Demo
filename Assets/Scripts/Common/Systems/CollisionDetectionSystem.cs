using System.Collections.Generic;
using Entitas;
using Entitas.VisualDebugging.Unity;
using TMPro;
using UnityEngine;


public class CollisionDetectionSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public CollisionDetectionSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Collision);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCollision;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            //entity.collision.hitting.DestroyGameObject();
            Debug.Log($"Destroy {entity}");

            var hitting = (GameEntity) entity.collision.hitting;
            hitting.isDestroyed = true;

            entity.isDestroyed = true;
        }
    }
}