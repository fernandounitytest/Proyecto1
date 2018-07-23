using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotiquinScript : MonoBehaviour {
    [SerializeField] GameObject prefabParticulas;
    [SerializeField] GameObject puntoGeneracion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Jugador")
        {
            prefabParticulas.transform.position = puntoGeneracion.transform.position; 
            Instantiate(prefabParticulas);
            Destroy(this.gameObject);
        }
    }
}
