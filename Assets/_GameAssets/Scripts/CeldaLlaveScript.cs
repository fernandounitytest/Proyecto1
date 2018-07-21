using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeldaLlaveScript : MonoBehaviour {
    enum Estacion { Summer, Autum, Winter, Spring }
    [SerializeField] GameObject celdaLlave;
    [SerializeField] Estacion estacion;
    private const float MINIMO_CELDA = -90f;

	// Update is called once per frame
	void Update () {
        if (estacion == Estacion.Summer && GameManager.NUM_MALOS_MUERTOS_SUMMER == GameManager.NUM_MALOS_POR_FASE && celdaLlave.transform.position.y > MINIMO_CELDA)
        {
            celdaLlave.transform.Translate(Vector3.down * Time.deltaTime);
        }
        if (estacion == Estacion.Autum && GameManager.NUM_MALOS_MUERTOS_AUTUM == GameManager.NUM_MALOS_POR_FASE && celdaLlave.transform.position.y > MINIMO_CELDA)
        {
            celdaLlave.transform.Translate(Vector3.down * Time.deltaTime);
        }
    }
}
