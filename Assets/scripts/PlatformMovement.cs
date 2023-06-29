using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private float destroyPositionY;
    private Rigidbody2D rb2D;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
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
