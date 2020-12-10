using Entitas;
using UnityEngine;

public class RotateTankSystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _group;
    
    public RotateTankSystem(Contexts contexts)
    {
        _contexts = contexts;
        
        _group = contexts.game.GetGroup(GameMatcher.AllOf(
            GameMatcher.Rotation, GameMatcher.View));
    }

    public void Execute()
    {
        foreach (var entity in _group)
        {
            if (entity.isPlayer || entity.isClone)
            {
                var input = _contexts.input.input.value;
                var playerRotation = input * _contexts.game.gameConstants.value.rotationSpeed
                                           * Time.deltaTime;
                entity.ReplaceRotation(entity.rotation.value + playerRotation);
            }
        }
    }
}