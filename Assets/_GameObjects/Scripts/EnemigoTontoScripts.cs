using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoTontoScripts : MonoBehaviour {
    [SerializeField] float velocidadMovimiento = 5;
    [SerializeField] GameObject prefabParticulasMuerte;
    [SerializeField] float distanciaAtaque = 5;
    [SerializeField] int danyoAtaque = 5;
    [SerializeField] GameObject prefabParticulasExplosion;


    CharacterController miCC;

    JugadorScript jugador;

    private void Start()
    {
        InvokeRepeating("CambiarDireccion", Random.Range(3,5),Random.Range(3, 5));
    }

    private void Awake()
    {
        miCC = GetComponent<CharacterController>();
    }

    private void Update () {
        miCC.SimpleMove(miCC.transform.forward * velocidadMovimiento);
        IntentarAtacarAlJugador();
	}

    private void IntentarAtacarAlJugador()
    {
        JugadorScript jugador = GameManager.jugador;

        float distancia = Vector3.Distance(this.transform.position, jugador.transform.position);
        if (distancia < distanciaAtaque)
        {
            AtaqueSuicida(jugador);
        }
    }

    private void AtaqueSuicida(JugadorScript jugador)
    {
        //ATACAR
        jugador.RecibirDanyo(danyoAtaque);
        //Autodestrucción
        Instantiate(
            prefabParticulasExplosion,
            position: this.transform.position,
            rotation: Quaternion.identity);
        Destroy(this.gameObject);
    }

    public void RecibirDanyo(int danyo)
    {
        Debug.Log("¡AY!");
        Vector3 rotacionAAplicar = new Vector3(0, 180, 0);
        this.transform.Rotate(rotacionAAplicar);
        GameObject nuevasParticulasMuerte = Instantiate(prefabParticulasMuerte);
        nuevasParticulasMuerte.transform.position = this.transform.position;
        nuevasParticulasMuerte.transform.up += Vector3.up * 3;
        Destroy(this.gameObject);
    }

    private void CambiarDireccion()
    {
        float rotacionAleatoria = Random.Range(0, 360);
        Vector3 rotacionAAplicar = new Vector3(0, rotacionAleatoria, 0);
        this.transform.Rotate(rotacionAAplicar);
    }


    
}
