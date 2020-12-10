using System;
using Entitas;
using Powerups.Systems;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameConstants gameConstants;
    private Systems _systems;
    private Contexts _contexts;

    private void Start()
    {
        _contexts = Contexts.sharedInstance;
        
        _contexts.game.ReplaceGameConstants(gameConstants);

        _systems = new GameSystems(_contexts);
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
            
            _contexts.Reset();
            
            this._systems = null;
        }
    }
}
