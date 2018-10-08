using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Range(1, 10)]
    public float movement_speed = 1;

    public Vector3 Target_Position { get; set; }
    public float Target_Rotation { get; set; }

    public GameObject Bullet_Prefab = null;

    private void Start()
    {
        Target_Position = this.transform.position;

        Target_Rotation = 0.0f;
    }


    private void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, Target_Position, movement_speed * Time.deltaTime);
    }

    public void Update_Rotation()
    {
        this.transform.Rotate(Vector3.up * Target_Rotation * (42 * Time.deltaTime));
        Target_Rotation = 0.0f;
    }

    public void Fire()
    {

        GameObject temp_bullet = GameObject.Instantiate(Bullet_Prefab, new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z), Quaternion.identity);

        temp_bullet.GetComponent<Bullet_Hit>().Target_Position = this.transform.forward * 10;

    }





}
