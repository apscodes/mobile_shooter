using UnityEngine;

public class Bullet_Hit : MonoBehaviour
{

    [Range(1, 10)]
    public float movement_speed = 1;
    public Vector3 Target_Position { get; set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }

    private void Start()
    {
        Destroy(gameObject, 10);
    }

    private void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, Target_Position, movement_speed * Time.deltaTime);
    }


}
