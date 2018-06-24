using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoTontoScripts : MonoBehaviour {
    [SerializeField] float velocidadMovimiento = 5;
    CharacterController miCC;

    private void Start()
    {
        InvokeRepeating("CambiarDireccion", 0, Random.Range(3, 5));
    }

    private void Awake()
    {
        miCC = GetComponent<CharacterController>();
    }

    private void Update () {
        miCC.SimpleMove(miCC.transform.forward * velocidadMovimiento);
	}

    public void RecibirDanyo(int danyo)
    {
        Debug.Log("¡AY!");
        Vector3 rotacionAAplicar = new Vector3(0, 180, 0);
        this.transform.Rotate(rotacionAAplicar);
    }

    private void CambiarDireccion()
    {
        float rotacionAleatoria = Random.Range(0, 360);
        Vector3 rotacionAAplicar = new Vector3(0, rotacionAleatoria, 0);
        this.transform.Rotate(rotacionAAplicar);
    }

}
