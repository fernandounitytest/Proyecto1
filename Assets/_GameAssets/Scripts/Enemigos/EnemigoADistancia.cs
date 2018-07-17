using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoADistancia : EnemigoBase {
    [SerializeField] float distanciaAtaque = 50;
    [SerializeField] float tiempoEntreDisparos = 2;
    [SerializeField] float fuerzaDisparo = 10;
    [SerializeField] float velocidadRotacion;

    [SerializeField] Transform canyon;
    [SerializeField] Transform puntoDisparo;

    [SerializeField] Rigidbody prefabProyectil;

    Quaternion rotacionInicialCanyon;
    float tiempoUltimoDisparo;
    

	void Start () {
        rotacionInicialCanyon = canyon.rotation;
	}
	
	void Update () {
        Vector3 miPosicion = this.transform.position;
        Vector3 posicionJugador = GameManager.jugador.transform.position;
        float distancia = Vector3.Distance(miPosicion, posicionJugador);
        if (distancia < distanciaAtaque)
        {
            AtacarAlJugador();
        } else
        {
            VolverARotacionInicial();
        }
	}

    void AtacarAlJugador()
    {
        canyon.LookAt(GameManager.jugador.transform.position);
        float tiempoActual = Time.time;
        if (tiempoActual > tiempoUltimoDisparo + tiempoEntreDisparos)
        {
            tiempoUltimoDisparo = tiempoActual;

            Rigidbody nuevoProyectil = Instantiate(prefabProyectil);
            nuevoProyectil.transform.position = puntoDisparo.transform.position;
            nuevoProyectil.transform.rotation = puntoDisparo.transform.rotation;
            nuevoProyectil.AddForce(puntoDisparo.forward * fuerzaDisparo, ForceMode.Impulse);

        }
    }
    void VolverARotacionInicial()
    {
        canyon.rotation = Quaternion.RotateTowards(
            canyon.rotation,
            rotacionInicialCanyon,
            velocidadRotacion * Time.deltaTime);
    }
}
