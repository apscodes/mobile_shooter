//*! Using namespace(s)
using UnityEngine.UI;
using UnityEngine;


/// <summary>
/// Player Controls via the UI Buttons
/// </summary>
public class Button_Controls : MonoBehaviour
{

    private Player_Movement player_movement = null;


    private Vector2 movement_bounds_min = Vector2.zero;
    private Vector2 movement_bounds_max = Vector2.zero;



    private void Start()
    {
        player_movement = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game_Manager>().player.GetComponent<Player_Movement>();


        movement_bounds_min.x = -5;
        movement_bounds_max.x = 5;

        movement_bounds_min.y = -8;
        movement_bounds_max.y = 14;
    }

    private bool Within_Bounds(Vector3 target_position)
    {

        if ((target_position.x >= movement_bounds_min.x && target_position.x <= movement_bounds_max.x) && target_position.z >= movement_bounds_min.y && target_position.z <= movement_bounds_max.y)
        {
            return true;
        }
        else
        {

            return false;
        }

    }


    #region Movement Button Functions

    public void Move_Forward()
    {
        if (Within_Bounds(player_movement.Target_Position + new Vector3(0, 0, 1)))
            player_movement.Target_Position = player_movement.Target_Position += new Vector3(0, 0, 1);
    }


    public void Move_Backward()
    {
        if (Within_Bounds(player_movement.Target_Position + new Vector3(0, 0, -1)))
            player_movement.Target_Position = player_movement.Target_Position += new Vector3(0, 0, -1);
    }

    public void Move_Left()
    {
        if (Within_Bounds(player_movement.Target_Position + new Vector3(-1, 0, 0)))
            player_movement.Target_Position = player_movement.Target_Position += new Vector3(-1, 0, 0);
    }

    public void Move_Right()
    {
        if (Within_Bounds(player_movement.Target_Position + new Vector3(1, 0, 0)))
            player_movement.Target_Position = player_movement.Target_Position += new Vector3(1, 0, 0);
    }

    #endregion



    #region Rotate Button Functions

    public void Rotate_Forward()
    {
    }

    public void Rotate_Down()
    {

    }

    public void Rotate_Left()
    {

    }

    public void Rotate_Right()
    {

    }


    #endregion

}
