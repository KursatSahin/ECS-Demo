using System;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;
using Object = UnityEngine.Object;


public class DestroySystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    
    public DestroySystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Destroyed);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isDestroyed;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.hasView)
            {
                var view = entity.view.value;

                Debug.Log($"Destroy {entity}");
                entity.Destroy();

                view.Unlink();
                //Debug.Log($"Destroy {entity.view.value.name}");
                Object.Destroy(view);
            }
            else
            {
                entity.Destroy();
            }
        }
    }
}