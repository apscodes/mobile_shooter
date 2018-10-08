//*!----------------------------!*//
//*! Programmer: Alex Scicluna
//*!----------------------------!*//

//*! Using namespaces
using UnityEngine;

public class End_Game_Caller : MonoBehaviour
{


    private Game_Manager game_manager = null;

    private void Start()
    {
        game_manager = FindObjectOfType<Game_Manager>();
    }


    /// <summary>
    /// End Game Trigger
    /// </summary>
    /// <param name="other"> Main Camera being the player </param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            game_manager.End_Game_Call();
        }
    }


}
