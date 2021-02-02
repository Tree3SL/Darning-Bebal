using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    /* TODO:
     *
     * Later intending to allow players to choose a spirte or at least the gender of the sprite
     *
     * Add FOV
     *
     * Networking
     *
     */

    #region Private Fields

    private List<GameObject> inventory = new List<GameObject>();
    private float stunnedTime;

    /*[SerializeField]
    private MonoBehaviour playerController;
    [SerializeField]
    private MonoBehaviour playerAnimator;*/
 
    private PlayerAnimator animator;
    private PlayerController controller;

    #endregion



    #region Public Fields

    //public bool playerDown = false; // For Toy Prefab of character

    #endregion



    #region MonoBehaviour Callbacks

    private void Start()
    {
        animator = gameObject.GetComponent<PlayerAnimator>();
        controller = gameObject.GetComponent<PlayerController>();

        //playerController.enabled = true;
        //playerAnimator.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != gameObject.name && collision.gameObject.layer != 8)
        {
            stunnedTime = Time.time;
            DisableControls();
            animator.PlayStun();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            EnableControls();
            animator.PlayerUp();
        }
    }


    /*private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name != gameObject.name && collision.gameObject.layer != 8)
        {
            Debug.Log("Still Touching");
            StunTimer()
        }
    }*/


    #endregion



    #region Private Methods

    private void DisableControls()
    {
        controller.controlsEnabled = false;
    }

    private void EnableControls()
    {
        controller.controlsEnabled = true;
    }

    /*private void StunTimer(float time)
    {

    }*/

    #endregion



    #region Public Methods

    #endregion
}
