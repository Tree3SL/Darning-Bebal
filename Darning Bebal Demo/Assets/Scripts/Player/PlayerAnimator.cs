using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    #region Private Fields

    [SerializeField]
    private Sprite[] idle;
    [SerializeField]
    private Sprite[] walk;
    [SerializeField]
    private Sprite[] stun;
    
    private int currentSprite = 0;
    private SpriteRenderer player;
    private int animationType = 0;

    #endregion

    #region Public Fields

    public bool stunned = false;

    #endregion

    private void Start()
    {
        player = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!stunned)
        {
            bool input = Input.anyKey;

            if (!input)
            {
                IdleAnimation();
            }
            else
            {
                WalkAnimation(Input.GetAxis("Horizontal"));
            }

            currentSprite++;
        }
    }

    private void IdleAnimation()
    {
        if(animationType != 0)
        {
            animationType = 0;
            currentSprite = 0;
        }
        else if(currentSprite >= idle.Length)
        {
            currentSprite = 0;
        }

        player.sprite = idle[currentSprite];
    }

    private void WalkAnimation(float axis)
    {
        if(animationType != 1)
        {
            animationType = 1;
            currentSprite = 0;
        }
        else if(currentSprite >= walk.Length)
        {
            currentSprite = 0; ;
        }

        player.sprite = walk[currentSprite];

        if(axis < 0)
        {
            player.flipX = true;
        }
        else if(player.flipX)
        {
            player.flipX = false;
        }
    }

    private void StunAnimation()
    {
        //Debug.Log("StunAnimation Entered");
        //Debug.Log(animationType);
        if(animationType != 2)
        {
            animationType = 2;
            currentSprite = 0;
            /*if(!player.flipX)
            {
                player.flipX = true;
            }
            else
            {
                player.flipX = false;
            }*/
        }
        else if(currentSprite >= stun.Length)
        {
            currentSprite = 0;
        }
        /*else if(animationType == 2 && currentSprite == stun.Length - 1)
        {
            Debug.Log("In here");
            return;
        }*/

        player.sprite = stun[currentSprite];
        
    }

    public void PlayStun()
    {
        //Debug.Log("PlayStun Entered");
        stunned = true;

        for(int i = 0; i < stun.Length * 12; i++)
        {
            if (i % 12 == 0)
            {
                StunAnimation();
                currentSprite++;
            }

            /*for(int j = 0; j < 30; j++)
            {
                // Test waiting time
            }*/
        }
    }

    public void PlayerUp()
    {
        stunned = false;
    }
}
