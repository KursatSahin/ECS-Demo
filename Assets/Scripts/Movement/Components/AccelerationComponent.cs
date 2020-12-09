using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Event(EventTarget.Self)]
public sealed class AccelerationComponent : IComponent
{
    public Vector3 value;
}
