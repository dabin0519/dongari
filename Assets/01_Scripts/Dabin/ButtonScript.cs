using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    private Animator animD; // door애니메이터
    private Animator anim;  // button 애니메이터
    private bool doorOpen;

    private void Start()
    {
        animD = GameObject.Find("Door").GetComponent<Animator>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            anim.SetBool("isButtonD", true);
        }
    }

    public void ButtonDown()
    {
        animD.SetBool("isDoorOpen", true);
    }
}
