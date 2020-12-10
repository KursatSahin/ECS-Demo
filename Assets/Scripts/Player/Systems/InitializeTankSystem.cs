using Entitas;
using TMPro;
using UnityEngine;

public class InitializeTankSystem : IInitializeSystem
{
    private Contexts _contexts;
    
    public InitializeTankSystem (Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        var entity = _contexts.game.CreateEntity();
        entity.isPlayer = true;
        
        entity.AddShootingPreferences(
            _contexts.game.gameConstants.value.fireSpeed,
            _contexts.game.gameConstants.value.fireRate);
        
        entity.AddShootingTrigger(Time.time + entity.shootingPreferences.shootingRate);
        
        entity.AddPrefab(_contexts.game.gameConstants.value.playerPrefab);
        
        entity.AddPosition(Vector3.zero);
        
        entity.AddRotation(Vector3.zero);

        //entity.AddTimer(0f);
        
        //entity.AddDoubleSpeedPowerup(_contexts.game.gameConstants.value.fireSpeed);
        //entity.AddDoubleFirePowerup(true);
        //entity.AddDoubleRatePowerup(_contexts.game.gameConstants.value.fireRate);
        //entity.AddSideFirePowerup(true);
    }
}