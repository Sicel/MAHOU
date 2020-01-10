using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Attacks/Spell")]
public class Spell : ScriptableObject
{
    [SerializeField] private float damage;
    [SerializeField] private float manaCost;
    [SerializeField] private float maxRange;
    [SerializeField] private float castTime;
    [SerializeField] private SpellInfo spellInfo;
    [SerializeField] private Vector3 targetPosition;

    public Vector3 TargetPosition { get { return targetPosition; } } 

    private Ray ray;

    public void OnBeforeTargetting(Ray ray)
    {
        if (spellInfo.target == Target.None)
        {
            return;
        }

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, LayerMask.GetMask("Ground")))
        {
            targetPosition = hit.point;
        }
    }

    public void OnTargetting()
    {
        if (spellInfo.target != Target.None)
        {
            switch (spellInfo.targetType)
            {
                case TargetType.None:
                    break;
                case TargetType.Centered:
                    break;
                case TargetType.Limited:
                    break;
                case TargetType.Unlimited:
                    break;
            }
        }
    }

    public void BeforeCast()
    {

    }

    public void CastSpell()
    {

    }

    public void OnCast()
    {

    }

    public void AfterCast()
    {

    }
}
