using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeldaScript : MonoBehaviour {
    private bool abriendo = false;
    private const float MINIMO_CELDA = -90f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (abriendo && transform.position.y > MINIMO_CELDA)
        {
            transform.Translate(Vector3.down * Time.deltaTime);
        }
    }
    public void abreteSesamo()
    {
        this.abriendo = true;
    }
}
