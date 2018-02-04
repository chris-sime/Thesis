using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPosition : MonoBehaviour {


    private Vector3 position;
    private Vector3 direction;

    [SerializeField] ScaleSetterScriptableObject scaleSetter;

	// Use this for initialization
	void Start () {
        position = transform.position - transform.parent.position;
        direction = position.normalized;
        transform.Translate(direction * scaleSetter.distance);
        transform.localScale = transform.localScale * scaleSetter.scale;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.DrawLine(position, position + direction * 10, Color.red, Mathf.Infinity);
    }
}
