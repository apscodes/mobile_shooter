//*! Using namespace(s)
using UnityEngine;
using System.Collections.Generic;


/// <summary>
/// Using Awake to set the target player, use Start to grab that reference.
/// </summary>
public class Enemy_Manager : MonoBehaviour
{
    //*! Initialised with null
    [HideInInspector]
    public GameObject target_player = null;

    [HideInInspector]
    public List<Simple_Enemy_AI> enemy = new List<Simple_Enemy_AI>();


    private void Awake()
    {
        //*! Find the game object with the tag "Player"
        target_player = GameObject.FindGameObjectWithTag("Player");

        if (target_player == null)
        {
            Debug.LogError("Player GameObject could not be found, please check the tag is set to 'Player'");
        }


        for (int index = 0; index < this.transform.childCount; index++)
        {
            if (this.transform.GetChild(index).GetComponent<Simple_Enemy_AI>() != null)
            {
                enemy.Add(this.transform.GetChild(index).GetComponent<Simple_Enemy_AI>());
            }
        }

    }
}
