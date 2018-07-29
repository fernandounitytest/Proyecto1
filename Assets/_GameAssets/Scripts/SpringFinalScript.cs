using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringFinalScript : MonoBehaviour {
    enum Estacion { Summer, Autum, Winter, Spring }
    [SerializeField] GameObject malezaMovil;
    [SerializeField] Estacion estacion;
    private const float MINIMO_MALEZA = -90f;

	// Update is called once per frame
	void Update () {
        if (estacion == Estacion.Spring &&
            (GameManager.NUM_MALOS_MUERTOS_SPRING == (GameManager.NUM_MALOS_POR_FASE + GameManager.NUM_MALOS_A_DIST_POR_FASE) && 
            malezaMovil.transform.position.y > MINIMO_MALEZA))
        {
            malezaMovil.transform.Translate(Vector3.down * Time.deltaTime);
        }
    }
}
