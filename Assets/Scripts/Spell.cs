using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : ScriptableObject
{
    [SerializeField] private float damage;
    [SerializeField] private float range;
}
