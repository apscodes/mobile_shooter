//*! Using namespace(s)
using UnityEngine;

/// <summary>
/// Using Awake to set the target player, use Start to grab that reference.
/// </summary>
public class Enemy_Manager : MonoBehaviour
{
    //*! Initialised with null
    [HideInInspector]
    public GameObject target_player = null;


    private void Awake()
    {
        //*! Find the game object with the tag "Player"
        target_player = GameObject.FindGameObjectWithTag("Player");

        if (target_player == null)
        {
            Debug.LogError("Player GameObject could not be found, please check the tag is set to 'Player'");
        }
    }
}
