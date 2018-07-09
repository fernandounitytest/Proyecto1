using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolaScript : MonoBehaviour {

    #region Atributos

    [SerializeField] Rigidbody prefabProyectil;
    [SerializeField] Transform puntoDisparo;//El punto de origen del disparo

    [SerializeField] AudioSource audioRecarga;
    [SerializeField] AudioSource audioDisparo;
    [SerializeField] AudioSource audioRecargaFallida;

    [SerializeField] float fuerzaDisparo = 20;
    [SerializeField] float tiempoEntreDisparos = 1f;
    [SerializeField] float tiempoRecarga = 1.5f;
    
    [SerializeField] int municionMaximaInventario = 32;
    [SerializeField] int municionActualInventario = 8;

    [SerializeField] int municionMaximaCargador = 8;
    private int municionActualCargador;

    private bool estoyRecargando;
    private bool gatilloApretado;

    float tiempoUltimoDisparo;

    #endregion Atributos
    
    public int GetMunicionActualCargador()
    {
        return this.municionActualCargador;
    }
    public int GetMunicionActualInventario()
    {
        return this.municionActualInventario;
    }

    void Start () {
        municionActualCargador = municionMaximaCargador;
        municionActualInventario = Mathf.Min(municionActualInventario, municionMaximaInventario);
	}
	
    public void ApretarGatillo()
    {
        float tiempoActual = Time.time;
        float tiempoDesdeUltimoDisparo = tiempoActual - tiempoUltimoDisparo;

        bool puedoDisparar = true;
        puedoDisparar &= tiempoDesdeUltimoDisparo > tiempoEntreDisparos;
        puedoDisparar &= municionActualCargador > 0;
        puedoDisparar &= !estoyRecargando;

        if (puedoDisparar)
        {
            DispararProyectil();
        } else if (municionActualCargador == 0)
        {
            audioRecargaFallida.Play();
        }
    }

    public void SoltarGatillo()
    {

    }

    public void Recargar()
    {
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

    private void FinalizarRecarga()
    {
        int municionARecargar = municionMaximaCargador - municionActualCargador;
        municionARecargar = Mathf.Min(municionARecargar, municionActualInventario);
        municionActualInventario -= municionARecargar;
        municionActualCargador += municionARecargar;
        Debug.Log("MunicionActualCargador:" + municionActualCargador);
        estoyRecargando = false;
    }

    private void DispararProyectil()
    {
        audioDisparo.Play();
        municionActualCargador -= 1;
        Rigidbody nuevoProyectil = Instantiate(prefabProyectil);
        nuevoProyectil.position = puntoDisparo.position;
        nuevoProyectil.rotation = puntoDisparo.transform.rotation;
        nuevoProyectil.AddRelativeForce(Vector3.forward * fuerzaDisparo, ForceMode.Impulse);
    }
}
