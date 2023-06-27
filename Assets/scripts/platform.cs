using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private float destroyPositionY;


    void Update()
    {
        this.transform.Translate(Vector3.down * 0.001f * velocity);

        if(this.transform.position.y < destroyPositionY)
        {
            Destroy(this.gameObject);
        }
    }
}
