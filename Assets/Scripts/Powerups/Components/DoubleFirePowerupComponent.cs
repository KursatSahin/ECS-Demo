using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class DoubleFirePowerupComponent : IComponent, IPowerup
{
    public bool enabled = true;
}