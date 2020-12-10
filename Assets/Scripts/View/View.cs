using Entitas;
using Entitas.Unity;
using UnityEngine;

public class View : MonoBehaviour, IView, IPositionListener, IRotationListener, IDestroyedListener
{
    public virtual void Link(IEntity entity)
    {
        gameObject.Link(entity);
        var e = (GameEntity)entity;
        e.AddPositionListener(this);
        e.AddRotationListener(this);
        e.AddDestroyedListener(this);

        var pos = e.position.value;
        transform.localPosition = new Vector3(pos.x, pos.y);
    }

    public virtual void OnPosition(GameEntity entity, Vector3 value)
    {
        transform.localPosition = value;
    }

    public virtual void OnRotation(GameEntity entity, Vector3 value)
    {
        //transform.Rotate(value);
        transform.localRotation = Quaternion.Euler(value);
        Debug.Log(nameof(OnRotation) + " is called");
    }

    public virtual void OnDestroyed(GameEntity entity)
    {
        var singleEntity = Contexts.sharedInstance.game.GetEntitiesWithView(gameObject).SingleEntity();
        
        gameObject.Unlink();
        
        singleEntity.Destroy();

        Destroy(gameObject);
    }
}