using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutumGeneratorScript : MonoBehaviour {
    [SerializeField] GameObject hojaPrefab;
    [SerializeField] Transform puntoGeneracionHojas;

	// Use this for initialization
	void Start () {
        //InvokeRepeating("GenerateLeaf", 3, 5);
	}
	
    void GenerateLeaf()
    {
        GameObject hoja = Instantiate(hojaPrefab);
        hoja.transform.position = puntoGeneracionHojas.position;
        hoja.GetComponent<Rigidbody>().AddForce(
            new Vector3(
                Random.Range(-10, 10), 
                Random.Range(0, 10), 
                Random.Range(-10,10)
            ), 
        ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="proyectil")
            GenerateLeaf();
    }
}
