﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaAutomaticaScript : ArmaProyectilesScript {
    public override void ApretarGatillo()
    {
        InvokeRepeating("DispararArma", 0, tiempoEntreDisparos);
    }

    public override void SoltarGatillo()
    {
        CancelInvoke("DispararArma");
    }

    private void OnDisable()
    {
        CancelInvoke("DispararArma");
    }

}
