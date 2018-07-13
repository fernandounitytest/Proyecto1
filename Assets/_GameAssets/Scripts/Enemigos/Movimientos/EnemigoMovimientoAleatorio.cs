using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMovimientoAleatorio : MonoBehaviour {
    [SerializeField] protected float velocidadMovimiento = 5;
    [SerializeField] float tiempoCambioDireccion = 3;
    CharacterController miCC;

    private void Awake()
    {
        miCC = GetComponent<CharacterController>();
    }

    // Use this for initialization
    void Start () {
        InvokeRepeating("CambiarDireccion", tiempoCambioDireccion, tiempoCambioDireccion);

    }

    // Update is called once per frame
    void Update () {
        miCC.SimpleMove(miCC.transform.forward * velocidadMovimiento);
    }

    private void CambiarDireccion()
    {
        float rotacionAleatoria = Random.Range(0, 360);
        Vector3 rotacionAAplicar = new Vector3(0, rotacionAleatoria, 0);
        this.transform.Rotate(rotacionAAplicar);
    }
}
