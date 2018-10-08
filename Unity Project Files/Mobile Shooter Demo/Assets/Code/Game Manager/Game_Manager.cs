//*!----------------------------!*//
//*! Programmer: Alex Scicluna
//*!----------------------------!*//

//*! Using namespaces
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


/// <summary>
/// Game Controller based on the events
/// </summary>
public class Game_Manager : MonoBehaviour
{

    //*!----------------------------!*//
    //*!    Public Variables
    //*!----------------------------!*//
    #region Public Variables

    public GameObject Player = null;

    public GameObject Door;

    public GameObject Bullet_Prefab;

    public GameObject Enemy_Container = null;

    public List<Simple_Enemy_AI> enemy = new List<Simple_Enemy_AI>();

    public Text end_of_demo;

    #endregion



    //*!----------------------------!*//
    //*!    Unity Functions
    //*!----------------------------!*//
    #region Unity Functions

    /// <summary>
    /// Getting the player and enemy references
    /// </summary>
    private void Awake()
    {
        //*! Main Camera is the player
        Player = GameObject.FindGameObjectWithTag("MainCamera");

        //*! Iterate over the Enemy Container
        for (int index = 0; index < Enemy_Container.transform.childCount; index++)
        {
            //*! Does it have an Enemy AI Script attached
            if (Enemy_Container.transform.GetChild(index).GetComponent<Simple_Enemy_AI>() != null)
            {
                //*! Add it to the list
                enemy.Add(Enemy_Container.transform.GetChild(index).GetComponent<Simple_Enemy_AI>());

                //*! Set the first 5 to can seek to true - default is false
                if (index < 5)
                {
                    enemy[index].can_seek = true;
                }
            }
        }
    }

    #endregion


    //*!----------------------------!*//
    //*!    Custom Functions
    //*!----------------------------!*//

    //*! Public Access
    #region Public Functions
    
    /// <summary>
    /// Remove an enemy from the list based on its instance ID.
    /// Also check the count of enemies remaining to disable the door and enable the second wave
    /// </summary>
    /// <param name="target_instance_id"> Target Instance ID to remove the Enemy </param>
    /// <returns> Succesful removal of the target enemy </returns>
    public bool Delete_Enemy_By_ID(int target_instance_id)
    {
        //*! Iterate over the list in enemy
        foreach (var e in enemy)
        {
            //*! Found a matching Instance ID
            if (e.gameObject.GetInstanceID() == target_instance_id)
            {
                //*! Remove the current enemy that we are looking at.
                enemy.Remove(e);

                //*! Check the count of enemy's
                if (enemy.Count <= 5 && Door.activeSelf == true)
                {
                    //*! Disable the renderering of the door
                    Door.SetActive(false);

                    //*! Set the can seek to true for the remaining 5 enemies
                    Enable_Second_Wave();
                }
                else if (enemy.Count == 0)
                {
                    End_Of_Demo();
                }

                //*! Something removed.
                return true;
            }
        }

        //*! Nothing removed.
        return false;
    }


    #endregion

    //*! Private Access
    #region Private Functions

    private void End_Of_Demo()
    {
        //*! Set the text value
        end_of_demo.text = "End of game demo, thanks for playing.\n@apscodes";
        
        //*! Call in 10 seconds
        Invoke("End_Game", 10.0f);
    }

    //*! Closes the game in editor and build
    private void End_Game()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }


    /// <summary>
    /// Only call when the second wave is ready.
    /// </summary>
    private void Enable_Second_Wave()
    {
        //*! Iterate over the list
        foreach (var e in enemy)
        {
            //*! Allow the enemies to seek to the player.
            e.can_seek = true;

            e.gameObject.transform.position += new Vector3(0, 2, 0);
        }
    }

    #endregion

}

