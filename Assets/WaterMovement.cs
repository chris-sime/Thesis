using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour {

    public float scrollSpeed = 1F;
    public Material materialToOffeset;

    [SerializeField]
    [Range(-1, 1)]
    int directionX;

    [SerializeField]
    [Range(-1, 1)]
    int directionY;

    [SerializeField]
    [Range(0, 1)]
    int offsetX;

    [SerializeField]
    [Range(0, 1)]
    int offsetY;
    
    void Update()
    {
        float offsetx = directionX * offsetX * (Time.time / 4 * scrollSpeed);
        float offsety = directionY * offsetY * (Time.time / 4 * scrollSpeed);
        materialToOffeset.mainTextureOffset = new Vector2(offsetx, offsety);
    }
}
