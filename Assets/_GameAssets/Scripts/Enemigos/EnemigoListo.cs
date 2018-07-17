using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoListo : EnemigoBase {

    [SerializeField] float distanciaSeguimiento = 15;
    EnemigoMovimientoAleatorio miMovimientoAleatorio;
    EnemigoMovimientoSeguimiento miMovimientoSeguimiento;

    private void Awake()
    {
        miMovimientoAleatorio = GetComponent<EnemigoMovimientoAleatorio>();
        miMovimientoSeguimiento = GetComponent<EnemigoMovimientoSeguimiento>();
    }

    void Update () {
        Vector3 positionJugador = GameManager.jugador.transform.position;
        Vector3 miPosicion = this.transform.position;

        float distancia = Vector3.Distance(miPosicion, positionJugador);

        if (distancia < distanciaSeguimiento)
        {
            miMovimientoSeguimiento.enabled = true;
            miMovimientoAleatorio.enabled = false;
        } else
        {
            miMovimientoSeguimiento.enabled = false;
            miMovimientoAleatorio.enabled = true;
        }
	}
}
