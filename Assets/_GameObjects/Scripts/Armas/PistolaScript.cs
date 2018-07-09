using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolaScript : ArmaScript {

    public override void ApretarGatillo()
    {
        float tiempoActual = Time.time;
        float tiempoDesdeUltimoDisparo = tiempoActual - tiempoUltimoDisparo;

        bool puedoDisparar = true;

        puedoDisparar &= tiempoDesdeUltimoDisparo > tiempoEntreDisparos;

        if (puedoDisparar) {
            DispararArma();
        }
        
    }

}
