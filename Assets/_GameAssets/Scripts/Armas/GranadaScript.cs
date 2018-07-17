using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadaScript : MonoBehaviour {
    public enum TipoDetonacion {
        PorTiempo,
        PorColision
    }
    [SerializeField] float radioExplosion;
    [SerializeField] int danyo=100;
    [SerializeField] TipoDetonacion detonacion;
    [SerializeField] float tiempoExplosion;
    [SerializeField] GameObject prefabExplosion;
    [SerializeField] LayerMask layersExplosion;
    float temporizador;

	// Use this for initialization
	void Start () {
        temporizador = Time.time + tiempoExplosion;
	}
	
	// Update is called once per frame
	void Update () {
        if (detonacion==TipoDetonacion.PorTiempo && Time.time > temporizador)
        {
            Explotar();
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (detonacion == TipoDetonacion.PorColision)
        {
            Explotar();
        }
    }

    void Explotar()
    {
        DañarEnemigos();

        Instantiate(prefabExplosion,
                    position: this.transform.position,
                    rotation: Quaternion.identity);
        Destroy(this.gameObject);
    }

    void DañarEnemigos()
    {
        Collider[] collidersAfectados = Physics.OverlapSphere(
            position: this.transform.position, 
            radius: radioExplosion,
            layerMask: layersExplosion
            );
        for (int i = 0; i < collidersAfectados.Length; i++)
        {
            Personaje posiblePersonaje = collidersAfectados[i].GetComponent<Personaje>();
            if (posiblePersonaje != null)
            {
                Debug.Log("Granada haciendo daño a:" + posiblePersonaje.name);
                posiblePersonaje.RecibirDanyo(danyo);
            }
        }
    }
}
