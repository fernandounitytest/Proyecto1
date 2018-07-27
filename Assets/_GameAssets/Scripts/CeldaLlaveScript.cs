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
        if (estacion == Estacion.Summer && 
            (GameManager.NUM_MALOS_MUERTOS_SUMMER == (GameManager.NUM_MALOS_POR_FASE + GameManager.NUM_MALOS_A_DIST_POR_FASE) && 
            celdaLlave.transform.position.y > MINIMO_CELDA))
        {
            celdaLlave.transform.Translate(Vector3.down * Time.deltaTime);
        }
        else if (estacion == Estacion.Autum &&
            (GameManager.NUM_MALOS_MUERTOS_AUTUM == (GameManager.NUM_MALOS_POR_FASE + GameManager.NUM_MALOS_A_DIST_POR_FASE) && 
            celdaLlave.transform.position.y > MINIMO_CELDA))
        {
            celdaLlave.transform.Translate(Vector3.down * Time.deltaTime);
        }
        else if (estacion == Estacion.Winter && 
            (GameManager.NUM_MALOS_MUERTOS_WINTER == (GameManager.NUM_MALOS_POR_FASE + GameManager.NUM_MALOS_A_DIST_POR_FASE) && 
            celdaLlave.transform.position.y > MINIMO_CELDA))
        {
            celdaLlave.transform.Translate(Vector3.down * Time.deltaTime);
        }
        else if (true || estacion == Estacion.Spring &&
            (GameManager.NUM_MALOS_MUERTOS_SPRING == (GameManager.NUM_MALOS_POR_FASE + GameManager.NUM_MALOS_A_DIST_POR_FASE) && 
            celdaLlave.transform.position.y > MINIMO_CELDA))
        {
            celdaLlave.transform.Translate(Vector3.down * Time.deltaTime);
        }
    }
}
