using Powerups.Systems;

public sealed class GameSystems : Feature
{
    public GameSystems(Contexts contexts)
    {
        Add(new GameEventSystems(contexts));
        Add(new InputSystem(contexts));
        Add(new GlobalTimerUpdateSystem(contexts));
        Add(new DelayedSystem(contexts));
        Add(new InitializeTankSystem(contexts));
        Add(new InstantiateViewSystem(contexts));
        Add(new RotateTankSystem(contexts));
        Add(new DoubleRatePowerupSystem(contexts));
        Add(new DoubleSpeedPowerupSystem(contexts));
        Add(new DoubleFirePowerupSystem(contexts));
        Add(new DoubleFireShootingTriggerSystem(contexts));
        Add(new DoubleFireShootingSystem(contexts));
        Add(new ClonePowerupSystem(contexts));
        Add(new SideFirePowerupSystem(contexts));
        Add(new AccelerationSystem(contexts));
        //Add(new MoveProjectileSystem(contexts));
        Add(new MoveSystem(contexts));
        Add(new ShootingSystem(contexts));
        Add(new ShootingTriggerSystem(contexts));
        Add(new CollisionDetectionSystem(contexts));
        Add(new DestroySystem(contexts));
    }
}