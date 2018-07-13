using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMovimientoSeguimiento : MonoBehaviour {
    [SerializeField] float velocidadMovimiento = 5;
    CharacterController miCC;

    private void Awake()
    {
        miCC = GetComponent<CharacterController>();
    }

	void Update () {
        this.transform.LookAt(GameManager.jugador.transform);
        miCC.SimpleMove(this.transform.forward * velocidadMovimiento);
	}
}
