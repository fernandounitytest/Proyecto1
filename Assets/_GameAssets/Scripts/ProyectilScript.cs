using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilScript : MonoBehaviour {
    [SerializeField] float tiempoVida;
    [SerializeField] int danyo = 10;
    [SerializeField] bool dañaAEnemigos = true;
    [SerializeField] bool dañaAJugador = false;
    [SerializeField] GameObject prefabParticulasImpacto;



	void Start () {
        Destroy(this.gameObject, tiempoVida);
	}

    /*private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Enemigo"))
        {
            EnemigoTontoScripts enemigo = other.GetComponent<EnemigoTontoScripts>();
            enemigo.RecibirDanyo(danyo);
        }

        Destroy(this.gameObject);
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        GenerarParticulasImpacto(collision);
        HacerDañoAPersonaje(collision);
    }

    private void HacerDañoAPersonaje(Collision collision)
    {
        Personaje personaje = collision.collider.GetComponentInParent<Personaje>();
        if (personaje != null)
        {
            if ((personaje.CompareTag("Enemigo") && dañaAEnemigos)||(personaje.CompareTag("Jugador") && dañaAJugador))
            {
                personaje.RecibirDanyo(danyo);
            }
        }
    }

    private void GenerarParticulasImpacto(Collision collision)
    {
        GameObject nuevasParticulasImpacto = Instantiate(prefabParticulasImpacto);
        nuevasParticulasImpacto.transform.position = collision.transform.position;
    }

}
