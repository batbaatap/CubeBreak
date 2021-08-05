
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{   
    public GameObject delAnimPrefab;



    void Update() {
        if(transform.position.y <= -1)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "obstacle")
        {
            // Destroy(this.gameObject);
            Transform newParent = gameObject.GetComponent<Transform> ();

            GameObject dap = Instantiate(delAnimPrefab, this.transform.position, Quaternion.identity);
                    dap.transform.SetParent (newParent);

            MeshRenderer mr = GetComponent<MeshRenderer>();
            mr.enabled=false;
            
            StartCoroutine("WaitAndPrint");
        }
    }

    IEnumerator WaitAndPrint()
    {
        yield return new WaitForSeconds(.5f);
            Destroy(this.gameObject);
        // print("Coroutine ended: " + Time.time + " seconds");
    }
}
