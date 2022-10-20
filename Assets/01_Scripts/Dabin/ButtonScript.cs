using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [Tooltip("어느 플레이어와 상호작용 할 것 인지")]public LayerMask PlayerLayer;
    public Transform playerCheck;

    private Animator animDoor; // door애니메이터
    private Animator animButton;  // button 애니메이터
    private bool buttonDown;

    private void Start()
    {
        animDoor = GameObject.Find("Door").GetComponent<Animator>();
        animButton = GetComponent<Animator>();
    }

    private void Update()
    {
        buttonDown = Physics2D.OverlapCapsule(playerCheck.position, new Vector2(0.3f, 0.16f), CapsuleDirection2D.Horizontal, 0, PlayerLayer);

        if (buttonDown)
        {
            animButton.SetBool("isButtonD", true);
        }
    }

    public void ButtonDown()
    {
        animDoor.SetBool("isDoorOpen", true);
    }
}
