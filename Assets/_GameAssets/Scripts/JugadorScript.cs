using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;

using UnityEngine;

public class JugadorScript : MonoBehaviour {
    [SerializeField] int vidaMaxima = 100;
    private ArmaScript[] armas;
    private ArmaScript armaEquipada;
    private int vidaActual;
    private bool estoyMuerto;

    public ArmaScript GetArmaScript()
    {
        return this.armaEquipada;
    }

    public int GetVidaActual()
    {
        return vidaActual;
    }

    public void SetVidaActual(int vida)
    {
        this.vidaActual = vida;
    }

    public int GetVidaMaxima()
    {
        return vidaMaxima;
    }

    private void Awake()
    {
        GameManager.jugador = this;
        this.vidaActual = vidaMaxima;
        armas = GetComponentsInChildren<ArmaScript>();
        EquiparArma(0);
    }

    void Start () {
		
	}
	
	void Update ()
    {
        ComprobarInputDisparo();
        ComprobarInputCambioArma();
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

    public void RecibirDanyo(int danyoAAplicar)
    {
        SetVidaActual(Mathf.Max(0, GetVidaActual() - danyoAAplicar));
        if (GetVidaActual() == 0)
        {
            Morir();
        }
    }

    private void Morir()
    {
        this.enabled = false;
        GetComponent<CharacterController>().enabled = false;
        GetComponent<FirstPersonController>().enabled = false;
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
}
