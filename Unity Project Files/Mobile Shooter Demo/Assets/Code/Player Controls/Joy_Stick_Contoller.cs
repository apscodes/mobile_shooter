//*!----------------------------!*//
//*! Programmer: Alex Scicluna
//*!----------------------------!*//

//*! Using namespaces
using UnityEngine;


/// <summary>
/// Joy Stick Contolls for the player.
/// </summary>
public class Joy_Stick_Contoller : MonoBehaviour
{
    //*!----------------------------!*//
    //*!    Public Variables
    //*!----------------------------!*//
    #region Public Variables

    public GameObject Player = null;

    [Range(1, 10)]
    public float movement_speed = 1;

    public GameObject touch_point;
    public GameObject outer_circle; 
 
    #endregion
          

    //*!----------------------------!*//
    //*!    Private Variables
    //*!----------------------------!*//
    #region Private Variables

    private Vector3 start_point;
    private Vector3 current_point;
    private bool is_touching = false;

    #endregion
    


    //*!----------------------------!*//
    //*!    Unity Functions
    //*!----------------------------!*//
    #region Unity Functions
        	
	private void Update ()
    {
        Check_Touch_Input();
    }

    private void FixedUpdate()
    {
        if (is_touching == true)
        {
            Vector2 vec_between = current_point - start_point;
            Vector2 direction = Vector2.ClampMagnitude(vec_between, 1.0f) * -1;

            transform.Translate(new Vector3(direction.x, 0, direction.y) * movement_speed * Time.fixedDeltaTime);


            Vector2 vbt = outer_circle.transform.position - Input.mousePosition;
            Vector2 clamped_direction = Vector2.ClampMagnitude(vbt, 64.0f) * -1;//*! 64 max range

            touch_point.transform.position = (new Vector3(clamped_direction.x, clamped_direction.y, 0) + outer_circle.transform.position);

        }
        else
        {
            touch_point.SetActive(false);
            outer_circle.SetActive(false);
        }
    }

    #endregion


    private void Check_Touch_Input()
    {
        
            if (Input.GetMouseButtonDown(0))
            {
                start_point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                                                         Input.mousePosition.y,
                                                                         Camera.main.transform.position.z));

                touch_point.transform.position = start_point + new Vector3(Input.mousePosition.x, Input.mousePosition.y);
                outer_circle.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y);

                touch_point.SetActive(true);
                outer_circle.SetActive(true);
            }



            if (Input.GetMouseButton(0))
            {
                is_touching = true;

                current_point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                                                           Input.mousePosition.y,
                                                                           Camera.main.transform.position.z));

            }
            else
            {
                is_touching = false;
            }
    }

}
