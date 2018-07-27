﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIJugadorScript : MonoBehaviour {

    [SerializeField] Image barraVida;
    [SerializeField] Text textoMunicion;
    [SerializeField] Image imagenArma;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Jugador jugador = GameManager.jugador;
        ActualizarBarraVida(jugador);
        ActualizarMunicion(jugador);
    }

    private void ActualizarBarraVida(Jugador jugador)
    {
        float vidaActual = jugador.GetVidaActual();
        float vidaMaxima = jugador.GetVidaMaxima();
        float porcentaje = vidaActual / vidaMaxima;
        barraVida.fillAmount = porcentaje;
    }

    private void ActualizarMunicion(Jugador jugador)
    {
        ArmaScript arma = jugador.GetArmaScript();
        int municionCargador = arma.GetMunicionActualCargador();
        int municionInventario = arma.GetMunicionActualInventario();

        textoMunicion.text = municionCargador + " / " + municionInventario;

        //imagenArma.sprite = arma.GetIconoArma();

    }
}
