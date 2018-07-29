using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlaveEstacionScript : MonoBehaviour {
    [SerializeField] GameObject jugador;
    [SerializeField] GameObject origenAutum;
    [SerializeField] GameObject origenWinter;
    [SerializeField] GameObject origenSpring;
    [SerializeField] GameObject lluviaPrefab;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Cambiando de estación");
        if (GameManager.NUM_MALOS_MUERTOS_WINTER == GameManager.NUM_MALOS_POR_FASE + GameManager.NUM_MALOS_A_DIST_POR_FASE)
        {
            Debug.Log("---FIN INVIERNO---");
            jugador.transform.position = origenSpring.transform.position;
            //Cambiar la iluminación
            Light ambientLight = GameObject.Find("Sol").GetComponent<Light>();
            ambientLight.transform.rotation = Quaternion.Euler(new Vector3(0, 360, 0));
            RenderSettings.ambientIntensity = 1;
            Destroy(this.gameObject);
        } else if (GameManager.NUM_MALOS_MUERTOS_AUTUM == GameManager.NUM_MALOS_POR_FASE + GameManager.NUM_MALOS_A_DIST_POR_FASE)
        {
            Debug.Log("---FIN AUTUM---");
            jugador.transform.position = origenWinter.transform.position;
            //Parar la lluvia
            GameObject lluvia = GameObject.Find("Lluvia(Clone)");
            lluvia.SetActive(false);
            //Cambiar la iluminación
            Light ambientLight = GameObject.Find("Sol").GetComponent<Light>();
            ambientLight.transform.rotation = Quaternion.Euler(new Vector3(-90, -150, 0));
            RenderSettings.ambientIntensity = 0;
            Destroy(this.gameObject);
        } else if (GameManager.NUM_MALOS_MUERTOS_SUMMER == GameManager.NUM_MALOS_POR_FASE + GameManager.NUM_MALOS_A_DIST_POR_FASE)
        {
            Debug.Log("---FIN VERANO---");
            jugador.transform.position = origenAutum.transform.position;
            RenderSettings.ambientLight = new Color(0, 0, 0);
            GameObject lluvia = Instantiate(lluviaPrefab);
            Destroy(this.gameObject);
        } 
        


    }
}
