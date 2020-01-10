using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Make Seprate Files

public enum Element
{
    Water,
    Earth,
    Fire,
    Air
}

public enum Target
{
    None,
    Entity,
    Ground,
    Air
}

public enum TargetType
{
    None,
    Centered, // Centered on player
    Limited, // Can move certain locations (Within range)
    Unlimited // Can move anywhere (Within range)
}

public enum AirTargetShape
{
    None,
    Sphere,
    Cuboid,
    Cone,
    Cylinder
}

public enum GroundTargetShape
{
    None,
    Line,
    Circle,
    Rectangle,
    Ring,
    Cone
}

// TODO: Add ways to customize shapes (size, orientation etc.)
[System.Serializable]
public class SpellInfo
{
    public Element element;
    public Target target;
    public TargetType targetType;

    public AirTargetShape airShape;
    public GroundTargetShape groundShape;
}
