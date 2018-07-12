using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaProyectilesScript : ArmaScript {
    [SerializeField] protected Rigidbody prefabProyectil;
    [SerializeField] protected Transform puntoDisparo;//El punto de origen del disparo
    [SerializeField] protected float fuerzaDisparo = 20;
    [SerializeField] protected float tiempoEntreDisparos = 1f;

    [SerializeField] protected AudioSource audioDisparo;

    protected float tiempoUltimoDisparo;

    protected void DispararArma()
    {

        if (municionActualCargador > 0 && !estoyRecargando)
        {
            LanzarProyectil();
        }
        else if (municionActualCargador == 0 && !estoyRecargando)
        {
            audioRecargaFallida.Play();
        }
    }

    protected void LanzarProyectil()
    {
        tiempoUltimoDisparo = Time.time;
        audioDisparo.PlayOneShot(audioDisparo.clip);
        //audioDisparo.Play();
        municionActualCargador -= 1;
        Rigidbody nuevoProyectil = Instantiate(prefabProyectil);
        nuevoProyectil.position = puntoDisparo.position;
        nuevoProyectil.rotation = puntoDisparo.transform.rotation;
        nuevoProyectil.AddRelativeForce(Vector3.forward * fuerzaDisparo, ForceMode.Impulse);
    }
}
