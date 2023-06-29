using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.UIElements;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    //[SerializeField] bool isTheFirstPlatform = false;
    [SerializeField] private float velocity;
    [SerializeField] private float destroyPositionY;
    private Rigidbody2D rb2D;
    
    //[SerializeField] private Transform playerCheck;
    //[SerializeField] private LayerMask playerLayer;



    //private bool isGrounded()
    //{
    //    return Physics2D.OverlapCircle(playerCheck.position, 0.2f, playerLayer);
    //}

    private void awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }

    private void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb2D.velocity = new Vector2(0f,velocity);

            if (this.transform.position.y < destroyPositionY)
            {
                Destroy(this.gameObject);
            }
    }
}
