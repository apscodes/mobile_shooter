using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Range(1, 10)]
    public float movement_speed = 1;

    public Vector3 Target_Position { get; set; }


    private void Start()
    {
        Target_Position = this.transform.position;


    }


    private void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, Target_Position, movement_speed * Time.deltaTime);


    }


}
