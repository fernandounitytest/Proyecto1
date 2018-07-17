using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBillboard : MonoBehaviour {

    Camera camaraPrincipal;
	// Use this for initialization
	void Start () {
        camaraPrincipal = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.rotation = camaraPrincipal.transform.rotation;
	}
}
