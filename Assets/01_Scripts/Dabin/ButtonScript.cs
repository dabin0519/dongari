using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject door1;

    private Animator animD; // door�ִϸ�����
    private Animator anim;  // button �ִϸ�����
    private bool doorOpen;

    private void Start()
    {
        animD = GameObject.Find("Door").GetComponent<Animator>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("isButtonD", true);
            doorOpen = true; // *�������� : �ִϸ��̼� ������ doorOpen = true �� ����;
        }

        if (doorOpen)
        {
            ButtonDown();
            doorOpen = false;
        }
    }

    public void ButtonDown()
    {
        animD.SetBool("isButtonDown", true);
    }
}
