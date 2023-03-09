using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageZone", menuName = "Damage")]
public class DamageZone : ScriptableObject
{
    public int amountOfDamage;
    public float destroyTimer;
    public bool moving;
    public float movingSpeed;
}
