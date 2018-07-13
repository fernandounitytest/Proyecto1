using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoTonto : Personaje {

    [SerializeField] GameObject prefabParticulasMuerte;

    protected override void Morir()
    {
        Debug.Log("¡AY!");
        GameObject nuevasParticulasMuerte = Instantiate(prefabParticulasMuerte);
        nuevasParticulasMuerte.transform.position = this.transform.position;
        nuevasParticulasMuerte.transform.up += Vector3.up * 3;
        Destroy(this.gameObject);
    }

    
}
