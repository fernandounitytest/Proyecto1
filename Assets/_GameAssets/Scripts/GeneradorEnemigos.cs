using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GeneradorEnemigos : MonoBehaviour {
    
    [SerializeField] GameObject prefabEnemigo;
    [SerializeField] int numeroEnemigosAGenerar=GameManager.NUM_MALOS_POR_FASE;
    [SerializeField] float tiempoEntreEnemigos=4;
    [SerializeField] float radioZonaGeneracion=10;
    [SerializeField] float alturaInvocacion = 1;
    [SerializeField] GameManager.Estacion tipoEnemigo;

    int numeroEnemigosGenerado = 0;

	// Use this for initialization
	void Start () {
        InvokeRepeating("GenerarEnemigo", 0, tiempoEntreEnemigos);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void GenerarEnemigo()
    {
        if (numeroEnemigosGenerado < numeroEnemigosAGenerar)
        {
            Vector3 desplazamientoAleatorio =
            Random.insideUnitSphere * radioZonaGeneracion;
            desplazamientoAleatorio.y = 0;

            GameObject nuevoEnemigo = Instantiate(prefabEnemigo);
            nuevoEnemigo.transform.position =
                this.transform.position + desplazamientoAleatorio;
            nuevoEnemigo.transform.position +=
                Vector3.up * alturaInvocacion;
            numeroEnemigosGenerado++;
        } else
        {
            CancelInvoke("GenerarEnemigo");
        }
        
    }
}
