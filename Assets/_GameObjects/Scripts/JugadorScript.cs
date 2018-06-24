using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorScript : MonoBehaviour {
    private PistolaScript pistolaScript;
    private void Awake()
    {
        pistolaScript = GetComponentInChildren<PistolaScript>();
    }

    void Start () {
		
	}
	
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            pistolaScript.ApretarGatillo();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            pistolaScript.SoltarGatillo();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            pistolaScript.Recargar();
        }
	}
}
