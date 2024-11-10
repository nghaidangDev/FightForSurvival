using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/Character", order = 1)]
public class CharacterSO : ScriptableObject
{
    public float hp;
    public float damaged;
    public float speed;
}
