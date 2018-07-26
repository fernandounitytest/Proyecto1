using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaRaycastScript : ArmaScript {
    [SerializeField] float tiempoEntreDisparos;
    [SerializeField] protected AudioSource audioDisparo;
    [SerializeField] int daño = 100;
    [SerializeField] float zoomFOV = 15;
    [SerializeField] GameObject canvasFrancotirador;
    float initialFOV;
    protected float tiempoUltimoDisparo;
    private Camera camara;

    void Awake()
    {
        base.Start();
        camara = Camera.main;
        this.initialFOV = camara.fieldOfView;
    }

    private void OnDisable()
    {
        DesactivarZoom();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ActivarZoom();
        }
        if (Input.GetMouseButtonUp(1))
        {
            DesactivarZoom();
        }
    }

    public override void ApretarGatillo()
    {
        if (Time.time > tiempoUltimoDisparo + tiempoEntreDisparos)
        {
            if (municionActualCargador > 0)
            {
                tiempoUltimoDisparo = Time.time;
                audioDisparo.Play();
                LanzarRaycast();
            } else
            {
                audioRecargaFallida.Play();
            }
        } else if (municionActualCargador==0 && !estoyRecargando)
        {
            audioRecargaFallida.Play();
        }
    }

    private void LanzarRaycast()
    {
        Vector3 posicionCamara = camara.transform.position;
        Vector3 forwardCamara = camara.transform.forward;
        Ray rayo = new Ray(posicionCamara, forwardCamara);

        RaycastHit infoImpacto;
        if (Physics.Raycast(rayo, out infoImpacto))
        {
            Collider colliderImpactado = infoImpacto.collider;
            Personaje personaje = colliderImpactado.GetComponentInParent<Personaje>();
            if (personaje != null && personaje.CompareTag("Enemigo"))
            {
                //impacto
                personaje.RecibirDanyo(daño);
            }
        }


    }

    void ActivarZoom()
    {
        canvasFrancotirador.SetActive(true);
        camara.fieldOfView = 15;
    }

    void DesactivarZoom()
    {
        canvasFrancotirador.SetActive(false);
        camara.fieldOfView = this.initialFOV;
    }
    
}
