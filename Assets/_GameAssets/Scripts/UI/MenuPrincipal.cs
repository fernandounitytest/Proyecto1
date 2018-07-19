using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour {

	public void EmpezarJuego()
    {
        SceneManager.LoadScene(1);//Congela
        //SceneManager.LoadScene("1", LoadSceneMode.Additive);//Or single Additive superpone las escenas
        //SceneManager.LoadSceneAsync("1");//Asíncrona
    }
    public void SalirJuego()
    {
        Application.Quit();
    }
}
