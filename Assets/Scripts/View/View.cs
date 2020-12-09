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
        e.AddDestroyedListener(this);

        var pos = e.position.value;
        transform.localPosition = new Vector3(pos.x, pos.y);
    }

    public virtual void OnPosition(GameEntity entity, Vector3 value)
    {
        transform.localPosition = value;
        Debug.Log("burada debug var...");
    }

    public virtual void OnRotation(GameEntity entity, Vector3 value)
    {
        transform.localRotation = Quaternion.Euler(value);
    }

    public virtual void OnDestroyed(GameEntity entity)
    {
        gameObject.Unlink();
        Destroy(gameObject);
    }
}