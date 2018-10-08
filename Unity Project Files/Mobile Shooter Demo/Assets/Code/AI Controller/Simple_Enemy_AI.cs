//*!----------------------------!*//
//*! Programmer: Alex Scicluna
//*!----------------------------!*//

//*! Using namespaces
using UnityEngine; 

/// <summary>
/// Simple Enemy AI Logic Controller
/// </summary>
public class Simple_Enemy_AI : MonoBehaviour
{

    //*!----------------------------!*//
    //*!    Public Variables
    //*!----------------------------!*//
    #region Public Variables

    [Range(1, 5)]
    public float movement_speed = 1;


    [Range(1, 5)]
    public float min_distance_threshold = 1;

    [HideInInspector]
    public bool can_seek = false;

    #endregion

    //*!----------------------------!*//
    //*!    Private Variables
    //*!----------------------------!*//
    #region Private Variables

    private GameObject target = null;

    private Game_Manager game_manager = null;

    private float shoot_timer = 0.0f;

    #endregion


    //*!----------------------------!*//
    //*!    Unity Functions
    //*!----------------------------!*//
    #region Unity Functions

    private void Start()
    {
        //*! Game Manager Reference
        game_manager = FindObjectOfType<Game_Manager>();

        //*! Add in the player as the first target
        target = game_manager.Player;
    }
    
    private void Update()
    {
        //*! Main lock for 'in active' enemies 
        if (can_seek == true)
        {
            Move_Toward_Target();

            //*! Every X Seconds shoot at the player
            shoot_timer += Time.deltaTime;
            if (shoot_timer >= Random.Range(2.0f, 3.5f))
            {
                //*! Reset the shoot timer
                shoot_timer = 0.0f;
                //*! And shoot the target
                Shoot();
            }
        }
    }

    #endregion


    //*!----------------------------!*//
    //*!    Custom Functions
    //*!----------------------------!*//

    //*! Public Access
    #region Public Functions
        
    ///*! Handy debug option menu
    ///[ContextMenu("Shoot Player")]
    /// <summary>
    /// Shoots at the current targets position from the enemies current position
    /// </summary>
    public void Shoot()
    {
        //*! Create a new bullet using the game managers prefab
        GameObject bullet = Instantiate(game_manager.Bullet_Prefab,
                               new Vector3(transform.position.x,
                                           transform.position.y,
                                           transform.position.z),
                               Quaternion.identity);

        //*! Set the target position of the bullet
        bullet.GetComponent<Bullet_Hit>().Target_Position = target.transform.position;

        //*! Who fired the bullet - no friendly fire;
        bullet.GetComponent<Bullet_Hit>().whom_fired_it = "Enemy";

        //*! Auto destroy in 2.5 seconds
        Destroy(bullet, 2.5f);
    }

    #endregion
       
    //*! Private Access
    #region Private Functions

    /// <summary>
    /// Get the distance to target and move towards it.
    /// </summary>
    private void Move_Toward_Target()
    {
        //*! Calculate the distance to target
        float min_distance_to_target = (target.transform.position - transform.position).magnitude;

        //*! Above the minimun distance to seek
        if (min_distance_to_target > min_distance_threshold)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, movement_speed * Time.deltaTime);
        }
    }

    #endregion

          
}
