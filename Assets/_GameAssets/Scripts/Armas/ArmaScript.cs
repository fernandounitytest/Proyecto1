using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaScript : MonoBehaviour {
    #region Atributos

    [SerializeField] protected float tiempoRecarga = 1.5f;

    [SerializeField] protected int municionMaximaInventario = 32;
    [SerializeField] protected int municionActualInventario = 8;
    [SerializeField] protected int municionMaximaCargador = 8;

    [SerializeField] protected AudioSource audioRecarga;
    [SerializeField] protected AudioSource audioRecargaFallida;

    [SerializeField] private Sprite iconoArma;

    protected int municionActualCargador;

    protected bool estoyRecargando;
    protected bool gatilloApretado;

    #endregion Atributos


    public Sprite GetIconoArma()
    {
        return iconoArma;
    }


    public int GetMunicionActualCargador()
    {
        return this.municionActualCargador;
    }
    public int GetMunicionActualInventario()
    {
        return this.municionActualInventario;
    }


    protected virtual void Start()
    {
        municionActualCargador = municionMaximaCargador;
        municionActualInventario = Mathf.Min(municionActualInventario, municionMaximaInventario);
    }

    public virtual void ApretarGatillo() { }

    public virtual void SoltarGatillo() { }

    public virtual void Recargar() {
        Debug.Log("Recargando");
        bool cargadorATope = (municionActualCargador == municionMaximaCargador);
        bool tengoBalas = municionActualInventario > 0;

        if (!estoyRecargando)
        {
            audioRecarga.Play();
            estoyRecargando = true;
            Invoke("FinalizarRecarga", tiempoRecarga);
        }
        else if (!tengoBalas)
        {
            Debug.Log("NO BALAS");
            audioRecargaFallida.Play();
        }
    }

    protected void FinalizarRecarga()
    {
        int municionARecargar = municionMaximaCargador - municionActualCargador;
        municionARecargar = Mathf.Min(municionARecargar, municionActualInventario);
        municionActualInventario -= municionARecargar;
        municionActualCargador += municionARecargar;
        Debug.Log("MunicionActualCargador:" + municionActualCargador);
        estoyRecargando = false;
    }



}