using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NubesPortadaScript : MonoBehaviour {
    [SerializeField] float speed = 2;//Velocidad de movimiento de la nube

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
		
	}
}
