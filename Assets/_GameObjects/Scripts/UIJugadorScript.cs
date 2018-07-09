using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIJugadorScript : MonoBehaviour {

    [SerializeField] Image barraVida;
    [SerializeField] Text textoMunicion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        JugadorScript jugador = GameManager.jugador;
        ActualizarBarraVida(jugador);
        ActualizarTextoMunicion(jugador);
    }

    private void ActualizarBarraVida(JugadorScript jugador)
    {
        float vidaActual = jugador.GetVidaActual();
        float vidaMaxima = jugador.GetVidaMaxima();
        float porcentaje = vidaActual / vidaMaxima;

        barraVida.fillAmount = porcentaje;
    }

    private void ActualizarTextoMunicion(JugadorScript jugador)
    {
        ArmaScript arma = jugador.GetArmaScript();
        int municionCargador = arma.GetMunicionActualCargador();
        int municionInventario = arma.GetMunicionActualInventario();

        textoMunicion.text = municionCargador + " / " + municionInventario;

    }
}
