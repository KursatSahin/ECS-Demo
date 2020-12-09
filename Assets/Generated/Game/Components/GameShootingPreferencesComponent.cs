//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ShootingPreferencesComponent shootingPreferences { get { return (ShootingPreferencesComponent)GetComponent(GameComponentsLookup.ShootingPreferences); } }
    public bool hasShootingPreferences { get { return HasComponent(GameComponentsLookup.ShootingPreferences); } }

    public void AddShootingPreferences(float newShootingSpeed, float newShootingRate) {
        var index = GameComponentsLookup.ShootingPreferences;
        var component = (ShootingPreferencesComponent)CreateComponent(index, typeof(ShootingPreferencesComponent));
        component.shootingSpeed = newShootingSpeed;
        component.shootingRate = newShootingRate;
        AddComponent(index, component);
    }

    public void ReplaceShootingPreferences(float newShootingSpeed, float newShootingRate) {
        var index = GameComponentsLookup.ShootingPreferences;
        var component = (ShootingPreferencesComponent)CreateComponent(index, typeof(ShootingPreferencesComponent));
        component.shootingSpeed = newShootingSpeed;
        component.shootingRate = newShootingRate;
        ReplaceComponent(index, component);
    }

    public void RemoveShootingPreferences() {
        RemoveComponent(GameComponentsLookup.ShootingPreferences);
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

    static Entitas.IMatcher<GameEntity> _matcherShootingPreferences;

    public static Entitas.IMatcher<GameEntity> ShootingPreferences {
        get {
            if (_matcherShootingPreferences == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ShootingPreferences);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherShootingPreferences = matcher;
            }

            return _matcherShootingPreferences;
        }
    }
}
