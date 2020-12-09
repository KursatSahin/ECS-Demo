//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public DoubleFireShootingTriggerComponent doubleFireShootingTrigger { get { return (DoubleFireShootingTriggerComponent)GetComponent(GameComponentsLookup.DoubleFireShootingTrigger); } }
    public bool hasDoubleFireShootingTrigger { get { return HasComponent(GameComponentsLookup.DoubleFireShootingTrigger); } }

    public void AddDoubleFireShootingTrigger(float newValue) {
        var index = GameComponentsLookup.DoubleFireShootingTrigger;
        var component = (DoubleFireShootingTriggerComponent)CreateComponent(index, typeof(DoubleFireShootingTriggerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceDoubleFireShootingTrigger(float newValue) {
        var index = GameComponentsLookup.DoubleFireShootingTrigger;
        var component = (DoubleFireShootingTriggerComponent)CreateComponent(index, typeof(DoubleFireShootingTriggerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveDoubleFireShootingTrigger() {
        RemoveComponent(GameComponentsLookup.DoubleFireShootingTrigger);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherDoubleFireShootingTrigger;

    public static Entitas.IMatcher<GameEntity> DoubleFireShootingTrigger {
        get {
            if (_matcherDoubleFireShootingTrigger == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DoubleFireShootingTrigger);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDoubleFireShootingTrigger = matcher;
            }

            return _matcherDoubleFireShootingTrigger;
        }
    }
}
