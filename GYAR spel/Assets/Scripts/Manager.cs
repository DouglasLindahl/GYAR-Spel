using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Dictionary<string, Player> players = new Dictionary<string, Player>();


    public static void RegisterPlayer(string netId, Player player)
    {
        string playerId = "Player " + netId;
        players.Add(playerId, player);
        player.transform.name = playerId;
    }
}
