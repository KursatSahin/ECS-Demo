using System.Collections.Generic;
using System.Numerics;
using Entitas;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Powerups.Systems
{
    public class ClonePowerupSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;
    
        public ClonePowerupSystem(Contexts contexts) : base(contexts.game) {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ClonePowerup.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isPlayer && entity.hasClonePowerup;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var cloneEntity = _contexts.game.CreateEntity();
                cloneEntity.isClone = true;
                cloneEntity.AddPosition(new Vector3(2,0,0));

                var componentIndices = entity.GetComponentIndices();
                
                foreach (var index in componentIndices)
                {
                    var component = entity.GetComponent(index);
                    
                    if (component is ClonePowerupComponent ||
                        component is PlayerComponent || 
                        component is PositionComponent || 
                        component is PositionListenerComponent || 
                        //component is RotationComponent || 
                        component is RotationListenerComponent || 
                        component is InputComponent ||
                        component is ViewComponent || 
                        component is DestroyedListenerComponent)
                        continue;
                    
                    cloneEntity.ReplaceComponent(index, component);
                }
            }
        }
    }
}