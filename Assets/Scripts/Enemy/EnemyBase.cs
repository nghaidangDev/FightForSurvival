using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")] 
public class EnemyBase : ScriptableObject
{
    public new string name;

    public Sprite artEnemy;

    public int speed;
    public int attack;
    public int health;
}
