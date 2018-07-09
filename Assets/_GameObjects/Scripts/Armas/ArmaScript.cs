using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaScript : MonoBehaviour {
    #region Atributos

    [SerializeField] protected Rigidbody prefabProyectil;
    [SerializeField] protected Transform puntoDisparo;//El punto de origen del disparo

    [SerializeField] protected AudioSource audioRecarga;
    [SerializeField] protected AudioSource audioDisparo;
    [SerializeField] protected AudioSource audioRecargaFallida;

    [SerializeField] protected float fuerzaDisparo = 20;
    [SerializeField] protected float tiempoEntreDisparos = 1f;
    [SerializeField] protected float tiempoRecarga = 1.5f;

    [SerializeField] protected int municionMaximaInventario = 32;
    [SerializeField] protected int municionActualInventario = 8;

    [SerializeField] protected int municionMaximaCargador = 8;
    protected int municionActualCargador;

    protected bool estoyRecargando;
    protected bool gatilloApretado;

    protected float tiempoUltimoDisparo;

    #endregion Atributos

    public int GetMunicionActualCargador()
    {
        return this.municionActualCargador;
    }
    public int GetMunicionActualInventario()
    {
        return this.municionActualInventario;
    }


    void Start()
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

    protected void DispararArma()
    {
        
        if (municionActualCargador > 0 && !estoyRecargando)
        {
            LanzarProyectil();
        }
        else if (municionActualCargador == 0 && !estoyRecargando)
        {
            audioRecargaFallida.Play();
        }
    }

    protected void LanzarProyectil()
    {
        audioDisparo.Play();
        municionActualCargador -= 1;
        Rigidbody nuevoProyectil = Instantiate(prefabProyectil);
        nuevoProyectil.position = puntoDisparo.position;
        nuevoProyectil.rotation = puntoDisparo.transform.rotation;
        nuevoProyectil.AddRelativeForce(Vector3.forward * fuerzaDisparo, ForceMode.Impulse);
    }


}