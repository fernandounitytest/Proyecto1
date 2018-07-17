using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemigo : MonoBehaviour {

    [SerializeField] Image frontalBarraVida;
    Personaje miPersonaje;

    private void Awake()
    {
        miPersonaje = GetComponentInParent<Personaje>();
    }

    void Update () {
        float vidaActual = miPersonaje.GetVidaActual();
        float vidaMaxima = miPersonaje.GetVidaMaxima();
        float porcentaje = vidaActual / vidaMaxima;
        frontalBarraVida.fillAmount = porcentaje;
	}
}
