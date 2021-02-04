using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Private Fields

    private Rigidbody2D playerRigidbody;
    private bool isMoving = false;

    #endregion

    #region Public Fields

    public float velocity = 30f;
    public bool controlsEnabled = true;

    #endregion

    #region Monobehaviour Callbacks

    private void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

   private void Update()
    {
        if(!controlsEnabled)
        {
            isMoving = false;
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            isMoving = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            isMoving = false;
        }
    }

    private void FixedUpdate() // Friction is needed to not slide
    {
        float axis = Input.GetAxis("Horizontal");
        Vector2 move = Vector2.zero;

        if (axis < 0)
        {
            move += (Vector2.left * velocity);
        }
        else if (axis > 0)
        {
            move += (Vector2.right * velocity);
        }

        MovePlayer(move);
    }

    #endregion


    #region Private Methods

    private void MovePlayer(Vector2 move)
    {
        if(isMoving)
        {
            playerRigidbody.velocity = move * Time.fixedDeltaTime;
        }
        else
        {
            playerRigidbody.velocity = Vector2.zero;
        }
    }

    #endregion
}
