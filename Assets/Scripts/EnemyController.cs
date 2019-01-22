using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 1f;
    private Rigidbody2D rigidbody;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

    }


    void Update()
    {
        if (isFacingRight())
        {
            rigidbody.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            rigidbody.velocity = new Vector2(-moveSpeed, 0f);
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        transform.localScale = new Vector2(-Mathf.Sign(rigidbody.velocity.x), 1f);
    }




    private bool isFacingRight()
    {
        return transform.localScale.x > 0f;
    }
}
