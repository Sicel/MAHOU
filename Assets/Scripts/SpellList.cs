using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell List", menuName = "Spell List")]
public class SpellList : ScriptableObject
{
    [SerializeField] private List<Spell> spells = new List<Spell>();

    public List<Spell> Spells { get { return spells; } }
}
