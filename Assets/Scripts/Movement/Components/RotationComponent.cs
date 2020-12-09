using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Event(EventTarget.Self)]
public class RotationComponent : IComponent// Euler rotation
{
    public Vector3 value;
}
