using UnityEngine;
using Entitas.CodeGeneration.Attributes;

[CreateAssetMenu]
[Game, Unique]
public class GameConstants : ScriptableObject
{
    public GameObject playerPrefab;
    public GameObject projectilePrefab;

    public float fireRate = 1f;
    public float fireSpeed = 10f;
    public float rotationSpeed = 180f;
}