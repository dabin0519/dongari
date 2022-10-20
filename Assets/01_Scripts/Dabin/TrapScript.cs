using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    [Tooltip("��� �÷��̾ ������ �װ� �� �� ����")] public LayerMask playerLayer;
    public float distance;

    RaycastHit2D playerHit;
    RaycastHit2D playerHitl;
    RaycastHit2D playerHitr;

    private void Update()
    {
        playerHit = Physics2D.BoxCast(transform.position, new Vector2(1.6f, 0.5f), 0f, Vector2.up, distance, playerLayer);
        playerHitl = Physics2D.BoxCast(transform.position, new Vector2(1.6f, 0.5f), 0f, Vector2.left, distance, playerLayer);
        playerHitr = Physics2D.BoxCast(transform.position, new Vector2(1.6f, 0.5f), 0f, Vector2.right, distance, playerLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && (playerHit.collider || playerHitl.collider || playerHitr))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
