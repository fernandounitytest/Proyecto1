﻿using UnityEngine.SceneManagement;
public class GameManager {
    public enum Estacion { Spring, Summer, Autum, Winter};
    public enum Estado { Jugando, GameOver};
    public static Jugador jugador;
    public static Estado estadoJuego = Estado.Jugando;
    public static Estacion estacionJugador = Estacion.Summer;
    public static int NUM_MALOS_POR_FASE=1;
    public static int NUM_MALOS_A_DIST_POR_FASE = 1;//Número de enemigos a distancia por fase
    public static int NUM_MALOS_MUERTOS_SUMMER = 0;
    public static int NUM_MALOS_MUERTOS_AUTUM = 0;
    public static int NUM_MALOS_MUERTOS_WINTER = 0;
    public static int NUM_MALOS_MUERTOS_SPRING = 0;


    public static void MostrarMenuVictoria()
    {
        SceneManager.LoadScene("MenuVictoria", LoadSceneMode.Additive);
    }

    public static void MostrarMenuDerrota()
    {
        SceneManager.LoadScene("MenuGameOver", LoadSceneMode.Additive);
    }

}
