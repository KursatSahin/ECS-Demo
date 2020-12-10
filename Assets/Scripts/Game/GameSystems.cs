using Powerups.Systems;

public sealed class GameSystems : Feature
{
    public GameSystems(Contexts contexts)
    {
        // Game Event Systems
        Add(new GameEventSystems(contexts));
        
        // Input Systems
        Add(new InputSystem(contexts));
        
        // Timer Systems
        Add(new GlobalTimerUpdateSystem(contexts));
        
        // Instantiate Systems
        Add(new InitializeTankSystem(contexts));
        Add(new InstantiateViewSystem(contexts));
        
        // Movement Systems
        Add(new AccelerationSystem(contexts));
        Add(new MoveSystem(contexts));
        Add(new RotateTankSystem(contexts));
        
        // Shooting Systems
        Add(new ShootingTriggerSystem(contexts));
        Add(new ShootingSystem(contexts));
        
        // PowerUp Systems
        Add(new SideFirePowerupSystem(contexts));
        Add(new DoubleFirePowerupSystem(contexts));
        Add(new DoubleFireShootingTriggerSystem(contexts));
        Add(new DoubleFireShootingSystem(contexts));
        Add(new DoubleRatePowerupSystem(contexts));
        Add(new DoubleSpeedPowerupSystem(contexts));
        Add(new ClonePowerupSystem(contexts));
        
        // Collision System
        Add(new CollisionDetectionSystem(contexts));
        
        // Destroy System
        Add(new DestroySystem(contexts));
    }
}