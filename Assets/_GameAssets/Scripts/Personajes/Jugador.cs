using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;

using UnityEngine;

public class Jugador : Personaje {
    private ArmaScript[] armas;
    private ArmaScript armaEquipada;
    private bool linternaActivada = false;
    [SerializeField] GameObject linterna;

    public ArmaScript GetArmaScript()
    {
        return this.armaEquipada;
    }

    

    private void Awake()
    {
        GameManager.jugador = this;
        armas = GetComponentsInChildren<ArmaScript>();
        EquiparArma(0);
    }

    
	void Update ()
    {
        ComprobarInputDisparo();
        ComprobarInputCambioArma();
        ComprobarInputLinterna();
    }

    private void ComprobarInputCambioArma()
    {
        for (int teclaArma = 1; teclaArma <= armas.Length; teclaArma++)
        {
            if (Input.GetKeyDown(teclaArma.ToString()))
            {
                EquiparArma(teclaArma - 1);
            }
        }
    }

    private void ComprobarInputDisparo()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            armaEquipada.ApretarGatillo();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            armaEquipada.SoltarGatillo();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            armaEquipada.Recargar();
        }
    }


    private void EquiparArma(int id)
    {
        for(int i=0; i<armas.Length; i++)
        {
            armas[i].gameObject.SetActive(false);
        }
        armaEquipada = armas[id];
        armaEquipada.gameObject.SetActive(true);
    }

    private void ComprobarInputLinterna()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            linternaActivada = !linternaActivada;
            linterna.SetActive(linternaActivada);
        }
    }

    protected override void Morir()
    {
        GameManager.estadoJuego = GameManager.Estado.GameOver;
        base.Morir();
        GameManager.MostrarMenuDerrota();
        GetComponent<CharacterController>().enabled = false;
        GetComponent<FirstPersonController>().enabled = false;
        Debug.Log("Acabas de morir");
    }
}
