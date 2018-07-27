using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAtaqueSuicida : MonoBehaviour {
    [Header("Ataque")]
    [SerializeField] float distanciaAtaque = 5;
    [SerializeField] int danyoAtaque = 5;
    [Header("Muerte")]
    [SerializeField] GameObject prefabParticulasMuerte;
    [SerializeField] GameObject prefabParticulasExplosion;

    private void Update()
    {
        IntentarAtacarAlJugador();
    }

    private void IntentarAtacarAlJugador()
    {
        Jugador jugador = GameManager.jugador;

        float distancia = Vector3.Distance(this.transform.position, jugador.transform.position);
        if (distancia < distanciaAtaque)
        {
            AtaqueSuicida(jugador);
        }
    }

    private void AtaqueSuicida(Jugador jugador)
    {
        ContarEnemigosMuertos();
        //ATACAR
        jugador.RecibirDanyo(danyoAtaque);
        //Autodestrucción
        Instantiate(
            prefabParticulasExplosion,
            position: this.transform.position,
            rotation: Quaternion.identity);
        Destroy(this.gameObject);
    }

    private void ContarEnemigosMuertos()
    {
        Debug.Log("¡AY!");
        //CONTROL DE ENEMIGOS
        if (GameManager.NUM_MALOS_MUERTOS_SUMMER < GameManager.NUM_MALOS_POR_FASE+GameManager.NUM_MALOS_A_DIST_POR_FASE)
        {
            GameManager.NUM_MALOS_MUERTOS_SUMMER++;
        }
        else if (GameManager.NUM_MALOS_MUERTOS_AUTUM < GameManager.NUM_MALOS_POR_FASE + GameManager.NUM_MALOS_A_DIST_POR_FASE)
        {
            GameManager.NUM_MALOS_MUERTOS_AUTUM++;
        }
        else if (GameManager.NUM_MALOS_MUERTOS_WINTER < GameManager.NUM_MALOS_POR_FASE + GameManager.NUM_MALOS_A_DIST_POR_FASE)
        {
            GameManager.NUM_MALOS_MUERTOS_WINTER++;
        }
        else if (GameManager.NUM_MALOS_MUERTOS_SPRING < GameManager.NUM_MALOS_POR_FASE + GameManager.NUM_MALOS_A_DIST_POR_FASE)
        {
            GameManager.NUM_MALOS_MUERTOS_SPRING++;
        }
    }
}
