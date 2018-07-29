using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuGameOver : MonoBehaviour {

	public void ReiniciarPartida()
    {
        Scene escenaActual = SceneManager.GetActiveScene();
        GameManager.estadoJuego = GameManager.Estado.Jugando;
        GameManager.estacionJugador = GameManager.Estacion.Summer;
        SceneManager.LoadScene(escenaActual.name,LoadSceneMode.Single);
        
    }
    public void SalirAlMenuPrincipal()
    {
        GameManager.estadoJuego = GameManager.Estado.Jugando;
        GameManager.estacionJugador = GameManager.Estacion.Summer;
        GameManager.estadoJuego = GameManager.Estado.Jugando;
        SceneManager.LoadScene("MenuPrincipal",LoadSceneMode.Single);
    }
}
