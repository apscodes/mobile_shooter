//*!----------------------------!*//
//*! Programmer: Alex Scicluna
//*!----------------------------!*//

//*! Using namespaces
using UnityEngine;

/// <summary>
/// Simple Door move, to target location.
/// </summary>
public class Simple_Door_Move : MonoBehaviour
{
    //*!----------------------------!*//
    //*!    Public Variables
    //*!----------------------------!*//
    #region Public Variables

    public Vector3 Target_Position { get; set; }

    #endregion
 

    private void Update ()
    {
        if (Target_Position != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target_Position, 1 * Time.deltaTime);
        }
	}
}
