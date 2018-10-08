using UnityEngine;


/// <summary>
/// Using Awake to set the player reference, use Start to grab that reference.
/// </summary>
public class Game_Manager : MonoBehaviour
{
    [HideInInspector]
    public GameObject player = null;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("Player GameObject could not be found, please check the tag is set to 'Player'");
        }
    }

}

