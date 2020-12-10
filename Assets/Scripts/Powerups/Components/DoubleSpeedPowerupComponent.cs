using Entitas;

[Game]
public class DoubleSpeedPowerupComponent : IComponent, IPowerup
{
    public float speedValue = 20f;
}
