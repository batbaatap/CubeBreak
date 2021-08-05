using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubebreak : MonoBehaviour
{
    public static Cubebreak instance{get; private set;} 
    bool flag = false;
	Vector3 screenPoint;
	float offset;


    //px movement
    public Vector3 lastPos;
    public Vector3 currentPos;
    Vector3 cp;

    
    public List<GameObject> allC = new List<GameObject>();

    Rigidbody2D rb2d;
    float spawnwoodtime;

    void Start() {
        instance = this;

        //px movement
        lastPos = currentPos;
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Cube movement by limit
        for(var o=0; o<1; o++)
        {
             if(allC.Count == 8) Limiter (-2.6f, 2.6f); 

             if(allC.Count == 7) 
             {
                Limiter (-2.7f, 2f);
             }

             if(allC.Count == 6) Limiter (-2.8f, 2.1f);
             if(allC.Count == 5) Limiter (-2.9f, 2.2f);
             if(allC.Count == 4) Limiter (-3f,   2.3f);
             if(allC.Count == 3) Limiter (-3.1f, 2.4f);
             if(allC.Count == 2) Limiter (-3.2f, 2.5f);
             if(allC.Count == 1) Limiter (-3.3f, 2.6f);
             if(allC.Count == 0) GameManager.Instance.GameOver();
        }
       

        if (GameManager.Instance.IsPlay())
        {
        
            if (Input.GetMouseButton(0))
            {
                if (flag==false)
                {
                    flag = true;
                    var mouse = Camera.main.ScreenToViewportPoint(Input.mousePosition * 7);
                    offset = gameObject.transform.localPosition.x - mouse.x;
                }

                Vector2 MousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition * 7);
                Debug.Log(MousePos);

                cp = MousePos + new Vector2(offset,0);
                // Debug.Log("cp" + cp);

                currentPos    = new Vector3(cp.x, transform.position.y, transform.position.z);
                // Debug.Log(currentPos);

                if(currentPos.x <= lastPos.x-0.1f)
                {
                    string s = (currentPos.x.ToString("0.0"));

                    Vector3 mr = new Vector3(float.Parse(s), transform.position.y, transform.position.z);
                    transform.position = mr;
                    lastPos = currentPos;
                }

                if(currentPos.x >= lastPos.x+0.1f)
                {
                    string s = (currentPos.x.ToString("0.0"));

                    Vector3 mr = new Vector3(float.Parse(s), transform.position.y, transform.position.z);
                    transform.position = mr;
                    lastPos = currentPos;
                }
                
                // if(currentPos.x <= lastPos.x-0.1f || currentPos.x >= lastPos.x+0.1f)
                // {
                //     string s = (currentPos.x.ToString("0.0"));

                //     Vector3 mr = new Vector3(float.Parse(s), transform.position.y, transform.position.z);
                //     transform.position = mr;
                //     lastPos = currentPos;
                // }

            } else {
                flag = false;
            }

            //bagana
            for(var i = 0; i < allC.Count; i++)
            {
                if(allC[i] == null)
                {
                    allC.RemoveAt(i);
                }
            }
        }
    }

    void Limiter(float zuunLimitPos, float baruunLimitPos)
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, zuunLimitPos, baruunLimitPos), 
        transform.position.y, 
        transform.position.z);
    }

}
