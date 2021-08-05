using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ob : MonoBehaviour
{
    int startScale;

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    void FixedUpdate() {
        if (GameManager.Instance.IsPlay())
        {
            transform.Translate(0, 0, -3f * Time.deltaTime);
        }
    }

    // void OnCollisionEnter(Collision other) {
    //    if(other.gameObject.name == "SpawnRoadCall")
    //     {
    //     }
    // }

}
