using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPlatform : MonoBehaviour
{
    private void OnCollisionExit2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
