using UnityEngine;
using System.Collections;

[System.Serializable]
public class Game {
    public static Game current;
    public Player player;

    public Game()
    {
        player = new Player();
    }
}
