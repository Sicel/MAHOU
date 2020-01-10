using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(SpellInfo))]
public class SpellInfoPropertyDrawer : PropertyDrawer
{
    private float currentLocation = 0;
    private float currentHeight = 16;
    private Rect rect;

    private Target targetEnum;
    private TargetType targetTypeEnum;
    private AirTargetShape airShapeEnum;
    private GroundTargetShape groundShapeEnum;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Spell spell = (Spell)property.serializedObject.targetObject;
        currentHeight = 16;
        currentLocation = position.y;
        rect = position;

        EditorGUI.BeginProperty(rect, label, property);
        SerializedProperty element = property.FindPropertyRelative("element");

        SerializedProperty target = property.FindPropertyRelative("target");
        targetEnum = (Target)target.enumValueIndex;

        SerializedProperty targetType = property.FindPropertyRelative("targetType");
        targetTypeEnum = (TargetType)targetType.enumValueIndex;

        SerializedProperty airTargetShape = property.FindPropertyRelative("airShape");
        airShapeEnum = (AirTargetShape)airTargetShape.enumValueIndex;

        SerializedProperty groundTargetShape = property.FindPropertyRelative("groundShape");
        groundShapeEnum = (GroundTargetShape)groundTargetShape.enumValueIndex;

        MakeHeader("Spell Target Info");
        MakePropertyField(element);
        MakePropertyField(target);
        switch (targetEnum)
        {
            case Target.Ground:
                targetTypeEnum = TargetType.Unlimited;
                groundShapeEnum = GroundTargetShape.Circle;
                MakePropertyField(targetType);
                MakePropertyField(groundTargetShape);
                break;
            case Target.Air:
                targetTypeEnum = TargetType.Unlimited;
                airShapeEnum = AirTargetShape.Sphere;
                MakePropertyField(targetType);
                MakePropertyField(airTargetShape);
                break;
            default:
                targetTypeEnum = TargetType.None;
                groundShapeEnum = GroundTargetShape.None;
                airShapeEnum = AirTargetShape.None;
                break;
        }


        currentHeight = currentLocation - position.y;
        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return currentHeight;
    }

    private void MakePropertyField(SerializedProperty property, int height = 16)
    {
        Rect propertyRect = new Rect(rect.x, currentLocation, rect.width, height);
        propertyRect = EditorGUI.PrefixLabel(propertyRect, new GUIContent(property.displayName));
        EditorGUI.PropertyField(propertyRect, property, GUIContent.none);
        currentLocation += EditorGUIUtility.singleLineHeight;
    }

    private void MakeHeader(string label, int space = 10, bool spaceAfter = false)
    {
        currentLocation += space;
        Rect labelRect = new Rect(rect.x, currentLocation, rect.width, 16);
        EditorGUI.LabelField(labelRect, new GUIContent(label), EditorStyles.boldLabel);
        currentLocation += spaceAfter ? space + 16 : 16;
    }
}
