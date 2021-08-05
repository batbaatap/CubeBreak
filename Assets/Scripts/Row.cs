using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    public List<GameObject> ColumnBox = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        for(var i = 0; i < ColumnBox.Count; i++)
        {
            if(ColumnBox[i] == null)
            {
                ColumnBox.RemoveAt(i);
            }
        }

        if(ColumnBox.Count == 0)
        {
            Destroy(this.gameObject);
        }
    }


}
