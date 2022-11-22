using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        if(x<0)
        transform.localScale=new Vector3(-1,1,1);
        else if(x>0)
        {
            transform.localScale=new Vector3(1,1,1);
        }
    }
}
