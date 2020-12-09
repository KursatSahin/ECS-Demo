using Entitas;
using UnityEngine;

[Game]
public class CollisionComponent : IComponent
{
    public IEntity hitting;
    public IEntity hitBy;
}