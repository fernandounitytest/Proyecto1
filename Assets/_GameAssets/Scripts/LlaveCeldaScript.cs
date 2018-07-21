using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlaveCeldaScript : MonoBehaviour {
    [SerializeField] GameObject celda;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ábrete, Sésamo");
        celda.GetComponent<CeldaScript>().abreteSesamo();
        Destroy(this.gameObject);
    }
}
