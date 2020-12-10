using Entitas;
using Entitas.Unity;
using UnityEngine;

public class CollisionTriggerEntityBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var entities = Contexts.sharedInstance.game.GetEntitiesWithView(other.gameObject);
        
        if (entities.Count > 0 && entities.SingleEntity().isShell)
        {
            return;
        }
        
        var entity = Contexts.sharedInstance.game.CreateEntity();

        var ownEntity = gameObject.GetEntityLink();
        var targetEntity = other.gameObject.GetEntityLink();

        entity.AddCollision(ownEntity.entity, ownEntity.entity);
        Debug.Log("Collision detected");
    }
}