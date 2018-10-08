using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Using Awake to set the player reference, use Start to grab that reference.
/// </summary>
public class Game_Manager : MonoBehaviour
{
    [HideInInspector]
    public GameObject player = null;

    public List<Simple_Enemy_AI> enemy = new List<Simple_Enemy_AI>();


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("Player GameObject could not be found, please check the tag is set to 'Player'");
        }

        enemy = GameObject.FindGameObjectWithTag("Enemy_Container").GetComponent<Enemy_Manager>().enemy;
    }





}

