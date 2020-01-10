using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [Header("Entity")]

    [SerializeField] protected float maxHealth = 100;
    [SerializeField] protected float maxMana = 100;
    [SerializeField] protected float maxStamina = 100;

    [SerializeField] protected float currentHealth = 100;
    [SerializeField] protected float currentMana = 100;
    [SerializeField] protected float currentStamina = 100;

    [SerializeField] protected bool targetable = true;
}
