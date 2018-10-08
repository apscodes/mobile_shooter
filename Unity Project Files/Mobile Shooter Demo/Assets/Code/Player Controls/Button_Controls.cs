//*!----------------------------!*//
//*! Programmer: Alex Scicluna
//*!----------------------------!*//

//*! Using namespaces
using UnityEngine;


/// <summary>
/// Player Controls via the UI Buttons
/// </summary>
public class Button_Controls : MonoBehaviour
{

    //*!----------------------------!*//
    //*!    Public Variables
    //*!----------------------------!*//
    #region Public Variables

    public GameObject Player;
    public float Target_Rotation { get; set; }

    #endregion
 
    //*!----------------------------!*//
    //*!    Private Variables
    //*!----------------------------!*//
    #region Private Variables

    private Game_Manager game_manager = null;

    private Zone room_one;
    private Zone room_two;

    private struct Zone
    {
        public Vector2 bounds_min;
        public Vector2 bounds_max;
    }

    #endregion


    //*!----------------------------!*//
    //*!    Unity Functions
    //*!----------------------------!*//
    #region Unity Functions
     
    /// <summary>
    /// Set room bounds and a reference to the game manager
    /// </summary>
    private void Start()
    {

        game_manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game_Manager>();

        //*! Set the bounds for Room One
        #region Room one area

        room_one.bounds_min.x = -5;
        room_one.bounds_max.x = 5;

        room_one.bounds_min.y = -8;
        room_one.bounds_max.y = 2;

        #endregion
               
        //*! Set the bounds for Room Two
        #region Room one area

        room_two.bounds_min.x = -5;
        room_two.bounds_max.x = 5;

        room_two.bounds_min.y = -8;
        room_two.bounds_max.y = 14;

        #endregion

    }

    #endregion




    //*!----------------------------!*//
    //*!    Custom Functions
    //*!----------------------------!*//

    //*! Public Access
    #region Public Functions

    /// <summary>
    /// Checking if the posible next position is within bounds before moving,
    /// if not do nothing.
    /// </summary>
    #region Movement Button Functions

    public void Move_Forward()
    {
        if (Within_Bounds(Player.transform.position + Player.transform.forward + Vector3.forward))
            Player.transform.Translate(Vector3.forward);
    }

    public void Move_Backward()
    {
        if (Within_Bounds(Player.transform.position + Player.transform.forward - Vector3.forward))
            Player.transform.Translate(-Vector3.forward);
    }


    public void Move_Left()
    {
        if (Within_Bounds(Player.transform.position + Player.transform.right - Vector3.right))
            Player.transform.Translate(-Vector3.right);
    }

    public void Move_Right()
    {
        if (Within_Bounds(Player.transform.position + Player.transform.right + Vector3.right))
            Player.transform.Translate(Vector3.right);
    }

    #endregion
    
    
    /// <summary>
    /// Rotate the player left or right 15 degrees
    /// </summary>
    #region Rotate Button Functions

    public void Rotate_Left()
    {
        Player.transform.Rotate(Vector3.up, -15);
    }

    public void Rotate_Right()
    {
        Player.transform.Rotate(Vector3.up, 15);
    }
 
        
    #endregion
       
    /// <summary>
    /// Player Shooting
    /// </summary>
    #region Fire / Shoot

    public void Shoot()
    {
        //*! Create a new bullet using the game managers prefab
        GameObject bullet = Instantiate(game_manager.Bullet_Prefab, 
                               new Vector3(Player.transform.position.x, 
                                           Player.transform.position.y, 
                                           Player.transform.position.z),
                               Player.transform.rotation);

        //*! Set the target position of the bullet
        bullet.GetComponent<Bullet_Hit>().Target_Position = transform.forward * 100;

        //*! Who fired the bullet - Player Shoot
        bullet.GetComponent<Bullet_Hit>().whom_fired_it = "Player";

        //*! Auto destroy in 2.5 seconds
        Destroy(bullet, 2.5f);
    }

    #endregion

    #endregion


    //*! Private Access
    #region Private Functions
    
    /// <summary>
    /// Check how many enemies are left then check the room bounds.
    /// </summary>
    /// <param name="target_position"></param>
    /// <returns> If the player can move in that direction. </returns>
    private bool Within_Bounds(Vector3 target_position)
    {
        if (game_manager.enemy.Count > 5)
        {
            if ((target_position.x >= room_one.bounds_min.x && target_position.x <= room_one.bounds_max.x) 
             && target_position.z >= room_one.bounds_min.y && target_position.z <= room_one.bounds_max.y)
            {
                return true;
            }
            else
            {

                return false;
            }
        }
        else
        {
            if ((target_position.x >= room_two.bounds_min.x && target_position.x <= room_two.bounds_max.x)
             && target_position.z >= room_two.bounds_min.y && target_position.z <= room_two.bounds_max.y)
            {
                return true;
            }
            else
            {

                return false;
            }
        }

    }

    #endregion

}
