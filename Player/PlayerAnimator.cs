using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    #region Private Fields

    [SerializeField]
    private Sprite[] idle;
    [SerializeField]
    private Sprite[] walk;
    
    private int currentSprite = 0;
    private SpriteRenderer player;
    private int animationType = 0;

    #endregion

    private void Start()
    {
        player = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        bool input = Input.anyKey;

        if(!input)
        {
            IdleAnimation();
        }
        else
        {
            WalkAnimation(Input.GetAxis("Horizontal"));
        }

        currentSprite++;
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
}
