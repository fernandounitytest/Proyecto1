using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaudScript : MonoBehaviour {
    [SerializeField] GameObject fps;
    [SerializeField] float ySuperior;
    [SerializeField] float distancia = 5;
    private bool moving = false;


    // Update is called once per frame
    void Update()
    {
        if (moving == false)
        {
            float dist = Vector3.Distance(fps.transform.position, this.transform.position);
            if (dist < distancia)
            {
                moving = true;
            }
        }
        else if (transform.localPosition.y< ySuperior)
        {

            transform.Translate(Vector3.up * Time.deltaTime * 0.1f);
        }
    }
}
