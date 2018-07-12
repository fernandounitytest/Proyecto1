using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArdillaScript : MonoBehaviour {
    private enum EstadosCabeza {Quieta, GirandoDerecha, GirandoIzquierda, Parando};
    private enum EstadosCola { Quieta, Bajando, Parando };
    private EstadosCabeza estadoCabeza = EstadosCabeza.Quieta;
    private EstadosCola estadoCola = EstadosCola.Quieta;
    private float speedRotacion = 3;
    private float speedCola = 15;
    [SerializeField] Transform cabeza;
    [SerializeField] Transform cola;
	// Use this for initialization
	void Start () {
        InvokeRepeating("GiraCabeza", 0, Random.Range(0f, 10f) + 5);
        InvokeRepeating("MueveCola", 0, Random.Range(1f, 10f));
	}

    private void Update()
    {
        ActualizarCabeza();
        ActualizarCola();
    }

    void GiraCabeza()
    {
        estadoCabeza = EstadosCabeza.GirandoDerecha;
    }

    void MueveCola()
    {
        estadoCola = EstadosCola.Bajando;
    }

    private void ActualizarCabeza()
    {
        if (estadoCabeza == EstadosCabeza.GirandoDerecha)
        {
            GirarCabezaDerecha();
        }
        else if (estadoCabeza == EstadosCabeza.GirandoIzquierda)
        {
            GirarCabezaIzquierda();
        }
        else if (estadoCabeza == EstadosCabeza.Parando)
        {
            PararCabeza();
        }
    }

    private void ActualizarCola()
    {
        if (estadoCola == EstadosCola.Bajando)
        {
            BajarCola();
        }
        else if (estadoCola == EstadosCola.Parando)
        {
            PararCola();
        }
    }
    
    private void GirarCabezaDerecha()
    {
        if (cabeza.localRotation.y < 0.20)
        {
            cabeza.transform.Rotate(0, speedRotacion, 0);
        }
        else
        {
            estadoCabeza = EstadosCabeza.GirandoIzquierda;
        }
    }

    private void GirarCabezaIzquierda()
    {
        if (cabeza.localRotation.y > -0.20)
        {
            cabeza.transform.Rotate(0, speedRotacion * -1, 0);
        }
        else
        {
            estadoCabeza = EstadosCabeza.Parando;
        }
    }
        
    private void PararCabeza()
    {
        cabeza.transform.Rotate(0, speedRotacion, 0);
        if (cabeza.localRotation.y >= 0)
        {
            estadoCabeza = EstadosCabeza.Quieta;
        }
    }

    private void BajarCola()
    {
        if (cola.localRotation.x > 0.2f)
        {
            cola.transform.Rotate(speedCola * -1, 0, 0);
        }
        else
        {
            estadoCola = EstadosCola.Parando;
        }
    }

    private void PararCola()
    {
        cola.transform.Rotate(speedCola, 0, 0);
        if (cola.localRotation.x >= 0.5)
        {
            estadoCola = EstadosCola.Quieta;
        }
    }

}
