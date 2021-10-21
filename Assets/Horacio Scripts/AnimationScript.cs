using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationScript : MonoBehaviour
{
    Animator anim;
    public static bool jump;
    //public static bool touching;
    public static bool handCloseToWall;
    public static bool handClick;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.move.y != 0)
        {
            anim.SetFloat("move", Mathf.Abs(GameController.move.y));

        }
        else if (GameController.move.x != 0)
        {
            anim.SetFloat("move", Mathf.Abs(GameController.move.x));

        }
        else
        {
            anim.SetFloat("move", 0);

        }
        anim.SetBool("jump", jump);
        //anim.SetBool("touching", touching);
        anim.SetBool("CloseToWall", handCloseToWall);
        anim.SetBool("OnClick", handClick);
        
        //Debug.Log(touching);
    }
}
