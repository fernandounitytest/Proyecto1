﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoBase : Personaje {

    [SerializeField] GameObject prefabParticulasMuerte;

    protected override void Morir()
    {
        Debug.Log("¡AY!");
        ContarEnemigosMuertos();

        GameObject nuevasParticulasMuerte = Instantiate(prefabParticulasMuerte);
        nuevasParticulasMuerte.transform.position = this.transform.position;
        nuevasParticulasMuerte.transform.up += Vector3.up * 3;
        Destroy(this.gameObject);
    }

    private static void ContarEnemigosMuertos()
    {
        //CONTROL DE ENEMIGOS
        if (GameManager.NUM_MALOS_MUERTOS_SUMMER < GameManager.NUM_MALOS_POR_FASE)
        {
            GameManager.NUM_MALOS_MUERTOS_SUMMER++;
        }
        else if (GameManager.NUM_MALOS_MUERTOS_AUTUM < GameManager.NUM_MALOS_POR_FASE)
        {
            GameManager.NUM_MALOS_MUERTOS_AUTUM++;
        }
        else if (GameManager.NUM_MALOS_MUERTOS_WINTER < GameManager.NUM_MALOS_POR_FASE)
        {
            GameManager.NUM_MALOS_MUERTOS_WINTER++;
        }
        else if (GameManager.NUM_MALOS_MUERTOS_SPRING < GameManager.NUM_MALOS_POR_FASE)
        {
            GameManager.NUM_MALOS_MUERTOS_SPRING++;
        }
    }

}
