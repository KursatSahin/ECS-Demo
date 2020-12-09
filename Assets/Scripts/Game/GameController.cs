using System;
using Entitas;
using Powerups.Systems;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameConstants gameConstants;
    private Systems _systems;

    private void Start()
    {
        var contexts = Contexts.sharedInstance;
        
        contexts.game.SetGameConstants(gameConstants);

        _systems = new GameSystems(contexts);
        //
        _systems.Initialize();
    }

    private void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }

    private void OnDestroy()
    {
        if (this._systems != null)
        {
            this._systems.TearDown();
            this._systems.DeactivateReactiveSystems();
            this._systems.ClearReactiveSystems();
            Contexts.sharedInstance.Reset();
            // Contexts.sharedInstance.game.DestroyAllEntities();
            // Contexts.sharedInstance.input.DestroyAllEntities();
            
            this._systems = null;
        }
    }
}
