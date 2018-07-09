using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;

using UnityEngine;

public class JugadorScript : MonoBehaviour {
    [SerializeField] int vidaMaxima = 100;
    private PistolaScript pistolaScript;
    private int vidaActual;
    private bool estoyMuerto;

    public PistolaScript GetPistolaScript()
    {
        return this.pistolaScript;
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
}
