//*! Using namespace(s)
using UnityEngine;
using System.Collections;

/// <summary>
/// Simple Vector3.MoveTowards the target postion logic.
/// </summary>
public class Simple_Enemy_AI : MonoBehaviour
{

    //*! Initialised with no target
    private GameObject target = null;

    //*! Default min_distance = 1
    [Range(1, 10)]
    [SerializeField]
    private int min_distance = 1;


    //*! Default movement speed = 1
    [Range(1, 10)]
    public float movement_speed = 1;

    public GameObject Bullet_Prefab = null;


    private float timer = 0.0f;

    private void Start()
    {
        //*! Set the target to be of the player via the Enemy_Manager
        target = GameObject.FindObjectOfType<Enemy_Manager>().target_player;


    }



    private void Update()
    {
        if (target != null)
        {
            Simple_Move();


            timer += Time.deltaTime;
            if (timer >= 5.0f)
            {
                Simple_Shoot();
                timer = 0.0f;
            }

        }

    }

    /// <summary>
    /// Only call if the target is not null
    /// </summary>
    private void Simple_Move()
    {
        //*! Move towards the target if they are more than the min_distance away
        if ((this.transform.position - target.transform.position).magnitude > min_distance)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, movement_speed * Time.deltaTime);
        }
    }


    private void Simple_Shoot()
    {
        Vector3 vec_between = target.transform.position - this.transform.position;

        GameObject temp_bullet = GameObject.Instantiate(Bullet_Prefab, new Vector3(this.transform.position.x, this.transform.position.y + 2, this.transform.position.z), Quaternion.identity);

        temp_bullet.GetComponent<Bullet_Hit>().Target_Position = target.transform.position;


    }



}
