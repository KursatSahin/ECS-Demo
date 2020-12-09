//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public DoubleFirePowerupComponent doubleFirePowerup { get { return (DoubleFirePowerupComponent)GetComponent(GameComponentsLookup.DoubleFirePowerup); } }
    public bool hasDoubleFirePowerup { get { return HasComponent(GameComponentsLookup.DoubleFirePowerup); } }

    public void AddDoubleFirePowerup(bool newEnabled) {
        var index = GameComponentsLookup.DoubleFirePowerup;
        var component = (DoubleFirePowerupComponent)CreateComponent(index, typeof(DoubleFirePowerupComponent));
        component.enabled = newEnabled;
        AddComponent(index, component);
    }

    public void ReplaceDoubleFirePowerup(bool newEnabled) {
        var index = GameComponentsLookup.DoubleFirePowerup;
        var component = (DoubleFirePowerupComponent)CreateComponent(index, typeof(DoubleFirePowerupComponent));
        component.enabled = newEnabled;
        ReplaceComponent(index, component);
    }

    public void RemoveDoubleFirePowerup() {
        RemoveComponent(GameComponentsLookup.DoubleFirePowerup);
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

    static Entitas.IMatcher<GameEntity> _matcherDoubleFirePowerup;

    public static Entitas.IMatcher<GameEntity> DoubleFirePowerup {
        get {
            if (_matcherDoubleFirePowerup == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DoubleFirePowerup);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDoubleFirePowerup = matcher;
            }

            return _matcherDoubleFirePowerup;
        }
    }
}
