//*!----------------------------!*//
//*! Programmer: Alex Scicluna
//*!----------------------------!*//

//*! Using namespaces
using UnityEngine;

/// <summary>
/// Bullet on hit logic
/// </summary>
public class Bullet_Hit : MonoBehaviour
{
    //*!----------------------------!*//
    //*!    Public Variables
    //*!----------------------------!*//
    #region Public Variables

    [Range(1, 10)]
    public float movement_speed = 1;

    public Vector3 Target_Position { get; set; }

    [HideInInspector]
    public string whom_fired_it = "";
    
    #endregion

    //*!----------------------------!*//
    //*!    Private Variables
    //*!----------------------------!*//
    #region Private Variables

    private Game_Manager game_manager;

    #endregion
    

    //*!----------------------------!*//
    //*!    Unity Functions
    //*!----------------------------!*//
    #region Unity Functions

    /// <summary>
    /// Set a reference for the game manager
    /// </summary>
    private void Start()
    {
        game_manager = FindObjectOfType<Game_Manager>();
    }
    
    /// <summary>
    /// Move towards the target position set
    /// </summary>
    private void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, Target_Position, movement_speed * Time.deltaTime);
    }

    /// <summary>
    /// When this bullet collides with another that is not it self or the object that shot it.
    /// </summary>
    /// <param name="other"> Other object hit </param> 
    /// <param name="whom_fired_it"> String used to determin if it was the player or the enemy that shot. 
    /// Could use a enum to prevent spelling errors. </param>
    private void OnTriggerEnter(Collider other)
    {
        //*! If it was the Player AND the other objects tag was the Enemy
        if (whom_fired_it == "Player")
        {
            if (other.tag == "Enemy")
            {
                //*! Remove the enemy from the list based on its instance id
                if (game_manager.Delete_Enemy_By_ID(other.gameObject.GetInstanceID()))
                {
                    //*! Destroy the enemy
                    Destroy(other.gameObject);
                    //*! Destroy this bullet
                    Destroy(gameObject);
                }
            }
        }
        //*! If it was the Enemy AND the other objects tag was the Player
        else if (whom_fired_it == "Enemy")
        {
            if (other.tag == "Player")
            {
                //*! Destroy this bullet
                Destroy(gameObject);
            }
        }
    }

    #endregion
}