using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlaveEstacionScript : MonoBehaviour {
    [SerializeField] GameObject jugador;
    [SerializeField] GameObject origenAutum;
    [SerializeField] GameObject origenWinter;
    [SerializeField] GameObject lluviaPrefab;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ábrete, Sésamo");
        if (GameManager.NUM_MALOS_MUERTOS_SPRING == GameManager.NUM_MALOS_POR_FASE)
        {
            //ACTIVAR EL BOSS
        } else if (GameManager.NUM_MALOS_MUERTOS_WINTER == GameManager.NUM_MALOS_POR_FASE)
        { 

        } else if (GameManager.NUM_MALOS_MUERTOS_AUTUM == GameManager.NUM_MALOS_POR_FASE)
        {
            jugador.transform.position = origenWinter.transform.position;
            GameObject.Find("Lluvia").SetActive(false);
            Destroy(this.gameObject);
        } else if (GameManager.NUM_MALOS_MUERTOS_SUMMER == GameManager.NUM_MALOS_POR_FASE)
        {
            jugador.transform.position = origenAutum.transform.position;
            GameObject lluvia = Instantiate(lluviaPrefab);
            Destroy(this.gameObject);
        } 




    }
}
