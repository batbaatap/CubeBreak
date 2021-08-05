using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    BoxCollider Col;
    private void Start() {
        Col= GetComponent<BoxCollider>();
    }
    // Update is called once per frame
    void Update()
    {
        // bagana
        // if(PlayerController.instance.allC.Count == 5){
        //     Col2d.size = new Vector3(0.1f,1,0);
        //     transform.localScale = new Vector3(0.1f,1,0);
        // }
        // if(PlayerController.instance.allC.Count == 4){
        //     Col2d.size = new Vector3(0.8f,1,0);
        //     transform.localScale = new Vector3(0.8f,1,0);
        // }
        // if(PlayerController.instance.allC.Count == 3){
        //     Col2d.size = new Vector3(0.6f,1,0);
        //     transform.localScale = new Vector3(0.6f,1,0);
        // }
        // if(PlayerController.instance.allC.Count == 2){
        //     Col2d.size = new Vector3(0.4f,1,0);
        //     transform.localScale = new Vector3(0.4f,1,0);
        // }
        // if(PlayerController.instance.allC.Count == 1){
        //     Col2d.size = new Vector3(0.2f,1,0);
        //     transform.localScale = new Vector3(0.2f,1,0);
        // }

        // doosh slide
        // transform.Translate(0, -0.5f * Time.deltaTime, 0);
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "obstacle")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    IEnumerator s(GameObject other)
    {
        yield return new WaitForSeconds(1f);
    }
    
}
