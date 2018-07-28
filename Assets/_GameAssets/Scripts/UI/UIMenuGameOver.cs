using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuGameOver : MonoBehaviour {

	public void ReiniciarPartida()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Scene escenaActual = SceneManager.GetActiveScene();
        SceneManager.LoadScene(escenaActual.name,LoadSceneMode.Single);
        
    }
    public void SalirAlMenuPrincipal()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("MenuPrincipal",LoadSceneMode.Single);
    }
}
