using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilScript : MonoBehaviour {
    [SerializeField] float tiempoVida;
    [SerializeField] int danyo = 10;
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
        GameObject nuevasParticulasImpacto = Instantiate(prefabParticulasImpacto);
        nuevasParticulasImpacto.transform.position = collision.transform.position;
        if (collision.collider.CompareTag("Enemigo"))
        {
            EnemigoTontoScripts enemigo = collision.collider.GetComponent<EnemigoTontoScripts>();
            enemigo.RecibirDanyo(danyo);
        }
    }

    
}
