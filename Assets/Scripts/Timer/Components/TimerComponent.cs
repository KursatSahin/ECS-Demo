using System.Runtime.Serialization;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class TimerComponent : IComponent
{
    public float currentTime;
}