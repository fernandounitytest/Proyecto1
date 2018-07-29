using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMenuYouWin : MonoBehaviour {
    [SerializeField] Text textSecondsLeft;
    private int secondsLeft = 5;
    private void Start()
    {
        secondsLeft = 5;
        InvokeRepeating("ContarAtras", 1, 1);
    }


    public void ContarAtras()
    {
        secondsLeft--;
        textSecondsLeft.text = secondsLeft.ToString();
        if (secondsLeft == 0)
        {
            CancelInvoke();
            Invoke("SalirAlMenuPrincipal",0);
        }
    }

    public void SalirAlMenuPrincipal()
    {
        GameManager.estadoJuego = GameManager.Estado.Jugando;
        GameManager.estacionJugador = GameManager.Estacion.Summer;
        GameManager.estadoJuego = GameManager.Estado.Jugando;
        SceneManager.LoadScene("MenuPrincipal",LoadSceneMode.Single);
    }
}
