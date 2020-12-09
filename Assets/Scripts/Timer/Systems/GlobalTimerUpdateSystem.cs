
using System;
using Entitas;
using UnityEngine;

public class GlobalTimerUpdateSystem : IInitializeSystem, IExecuteSystem
{
    private Contexts _contexts;
    private const float TICK_TIMER_MAX = .1f;
    private float _tickTimer;

    public GlobalTimerUpdateSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        var entity = _contexts.game.CreateEntity();
        entity.ReplaceTimer(0);
    }

    public void Execute()
    {
        var entities = _contexts.game.GetGroup(GameMatcher.Timer);

        _tickTimer += Time.deltaTime;
        
        if (_tickTimer >= TICK_TIMER_MAX)
        {
            _tickTimer -= TICK_TIMER_MAX;
            
            foreach (var entity in entities)
            {
                entity.ReplaceTimer(entity.timer.currentTime + TICK_TIMER_MAX);
            }
        }
        
    }
}