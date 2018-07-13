using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour {
    [SerializeField] protected int vidaMaxima = 100;
    protected int vidaActual;
    protected bool estoyMuerto;

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

    public void RecibirDanyo(int danyoAAplicar)
    {
        SetVidaActual(Mathf.Max(0, GetVidaActual() - danyoAAplicar));
        Debug.Log(GetVidaActual());
        if (GetVidaActual() == 0)
        {
            ComprobarMuerte();
        }
    }

    private void ComprobarMuerte()
    {
        if (!estoyMuerto)
        {
            estoyMuerto = true;
            Morir();
        }
    }

    protected virtual void Morir()
    {
        
    }

    protected virtual void Start()
    {
        this.vidaActual = vidaMaxima;
    }


    // Update is called once per frame
    void Update () {
		
	}
}
