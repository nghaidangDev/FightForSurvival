using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")] 
public class EnemyBase : ScriptableObject
{
    public new string name;

    public Sprite artEnemy;

    public float speed;
    public float attack;
    public float health;
}
