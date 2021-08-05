using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gem : MonoBehaviour
{

    bool adds;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, -3f * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    
    void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Player")
		{
            adds = true;

            if(adds == true)
            {
    			int currentGem = PlayerPrefs.GetInt("gemCountPrefs");
                currentGem ++;


                GemsManager gm = GameObject.Find("GemsManager").GetComponent<GemsManager>();

                gm.gemNumber.text = currentGem.ToString();
                
                PlayerPrefs.SetInt("gemCountPrefs", currentGem);
                
                adds = false;
            }

                Destroy(gameObject);
		}
	}

}
