using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunicionPistolaScript : MonoBehaviour {
    private GameObject jugador;
    [SerializeField] GameObject prefabParticulas;
    [SerializeField] GameObject puntoGeneracion;


    private void Awake()
    {
        jugador = GameObject.Find("Jugador");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Jugador")
        {
            jugador.GetComponentInChildren<ArmaScript>().RecargarInventario();
            prefabParticulas.transform.position = puntoGeneracion.transform.position; 
            Instantiate(prefabParticulas);
            Destroy(this.gameObject);
        }
    }
}
