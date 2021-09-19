using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderJumper : MonoBehaviour
{
    private Rigidbody2D mybody;

    private Animator anim;

    [SerializeField]
    private float minJumpForce = 5f , maxJumpForce = 12f;

    [SerializeField]
    private float minWaitTime = 1.5f , maxWaitTime = 3.5f ;

    private float jumpTime;

    private bool canJump;



    //------------------ALL THE FUNCTI0N BELOW ------------------------------ 

    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    private void Start()
    {
        jumpTime =  Time.time + Random.Range(minWaitTime, maxWaitTime);
                
    }

    private void Update()
    {
        //Debug.Log(mybody.velocity.magnitude);
        HandleJumping();
        HandleJumpAnimaton();
    }

    void HandleJumping()
    {
        if(Time.time > jumpTime)
        {
            jumpTime =  Time.time + Random.Range(minWaitTime, maxWaitTime);
            Jump();       
        }


        if(mybody.velocity.magnitude == 0)
        {
            canJump = true;
        }
    }

    void Jump()
    {
        if (canJump)
        {
            SoundController.instance.Play_SpiderAttack();
            canJump = false;
            mybody.velocity = new Vector2(0f, Random.Range(minJumpForce, maxJumpForce));
        }

    }

    void HandleJumpAnimaton()
    {
        if(mybody.velocity.magnitude == 0)
        
            anim.SetBool(TagManager.JUMP_ANIMATION_PARAMETER, false);
        else
            anim.SetBool(TagManager.JUMP_ANIMATION_PARAMETER, true);

        
    }

}
















