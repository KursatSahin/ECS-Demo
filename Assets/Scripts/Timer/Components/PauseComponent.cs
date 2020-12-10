using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class PauseComponent : IComponent
{
    public bool value;
}