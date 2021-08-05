using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemsManager : MonoBehaviour
{

    internal Text gemNumber;
    public const string gemCountPrefs = "gemCountPrefs";

    public GameObject GemPrefab;
    
    float Birthtime = 10;


    // Start is called before the first frame update
    void Start()
    {
        GameObject gemN = GameObject.Find("GemText");
        gemNumber = gemN.GetComponent<Text>();
        gemNumber.text = PlayerPrefs.GetInt(gemCountPrefs).ToString();
    }

    // Update is called once per frame
    void Update()
    {

        if(GameManager.Instance.IsPlay()) {
			
			float PlusBirthtime = Random.Range(1, 10);

			if(Time.time >= Birthtime){
				CloneGem();
				Birthtime = Time.time + PlusBirthtime;
			}
		}
        
    }


    void CloneGem()
	{
		float RightOrLeft = Random.Range(0,2);
		// print(RightOrLeft);
		// float tY = Mathf.Clamp (transform.localPosition.y, -20, 20);
		float leftsize  = Random.Range(-0.1f, -1f);
		float rightsize = Random.Range( 0.1f,  1f);

		Instantiate(GemPrefab,   Vector3.Lerp(new Vector3(leftsize, 0f, 40), new Vector3(rightsize, 0f, 40), RightOrLeft), Quaternion.identity);
	}

}
