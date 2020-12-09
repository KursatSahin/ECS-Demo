using Entitas;
using UnityEngine;

public class RotateTankSystem : IExecuteSystem
{
    private Contexts _contexts;
        
    public RotateTankSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        var input = _contexts.input.input.value;
        var playerTransform = _contexts.game.playerEntity.view.value.transform;
        var playerRotation = input * _contexts.game.gameConstants.value.rotationSpeed
                                  * Time.deltaTime;

        playerTransform.Rotate(playerRotation);
    }
}