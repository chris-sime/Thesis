using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectsScale", menuName = "Scale")]
public class ScaleSetterScriptableObject : ScriptableObject {

    [Range(1, 100)]
    public float scale;
    [Range(0, 100)]
    public float distance;

}
