using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadsGenerator : MonoBehaviour
{
    public List<GameObject> Roads = new List<GameObject>();

    int getRoad;

    int nemegdehuun;

    public bool cloneRoad;

    public List<float> AvSpaces = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating("SpawnRoad", 0, 6);
        
        float  n = -1.6f;
        while (n <= 1.6f)
        {
            n+=0.1f;

            AvSpaces.Add(n);

            if (n >= 1.5f)
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.Instance.IsPlay())
        {

            if(cloneRoad==true)
            {
                for (int q = 0; q < 1; q++)
                {
                    int RandomVal = Random.Range(0, AvSpaces.Count);


                    //naidvartaigaar ymar ch bsn zam gargagchiig hemjeenees n hamaarch huulj bn
                    if(Cubebreak.instance.allC.Count == 8)
                    {
                        ZamCloner(7, RandomVal);
                    }

                    if(Cubebreak.instance.allC.Count == 7)
                    {
                        ZamCloner(6, RandomVal);
                    }
                    
                    if(Cubebreak.instance.allC.Count == 6)
                    {
                        ZamCloner(5, RandomVal);
                    }

                    if(Cubebreak.instance.allC.Count == 5)
                    {
                        ZamCloner(4, RandomVal);
                    }

                    if(Cubebreak.instance.allC.Count == 4)
                    {
                        ZamCloner(3, RandomVal);
                    }

                    if(Cubebreak.instance.allC.Count == 3)
                    {
                        ZamCloner(2, RandomVal);
                    }

                    if(Cubebreak.instance.allC.Count == 2)
                    {
                        ZamCloner(1, RandomVal);
                    }

                    if(Cubebreak.instance.allC.Count == 1)
                    {
                        ZamCloner(0, RandomVal);
                    }

                    // hamaagui ali neg roadiig hevlej bn
                    int hamaaguiBarlald = Random.Range(0, AvSpaces.Count);
                    int El = Random.Range(0, Cubebreak.instance.allC.Count);
                    ZamCloner(El, hamaaguiBarlald);
                }
            }
            cloneRoad = false;

        
        }
    }

    void ZamCloner(int RIndex, int Ran)
    {
        Instantiate(Roads[RIndex], new Vector3(AvSpaces[Ran], transform.position.y, transform.position.z), Quaternion.identity);
    }


}

