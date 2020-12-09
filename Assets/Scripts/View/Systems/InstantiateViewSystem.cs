using System;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;
using Object = UnityEngine.Object;

public class InstantiateViewSystem : ReactiveSystem<GameEntity>
{
    readonly Transform _parent;
    
    public InstantiateViewSystem(Contexts contexts) : base(contexts.game)
    {
        _parent = new GameObject("Views").transform;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Prefab);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPrefab && !entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.AddView(InstantiateView(entity));
        }
    }

    GameObject InstantiateView(GameEntity entity)
    {
        var prefab = entity.prefab.value;
        var go = Object.Instantiate(prefab, _parent);
        var view  = go.GetComponent<IView>();
        view.Link(entity);
        return go;
    }
}