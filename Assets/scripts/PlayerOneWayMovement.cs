using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneWayMovement : MonoBehaviour
{
    private GameObject currentOneWayPlatform;

    [SerializeField] private BoxCollider2D playerCollider;


    void Update()
    {
        Debug.Log(Input.GetAxisRaw("Vertical"));
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            if (currentOneWayPlatform != null)
            {
                StartCoroutine(DisableCollision());
            }

        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = collision.gameObject;
            Debug.Log("One Way");
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = null;
        }
    }


    private IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = currentOneWayPlatform.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }


}
