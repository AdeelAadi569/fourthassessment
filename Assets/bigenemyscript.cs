using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bigenemyscript : MonoBehaviour
{
    
    public int counter=10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision col){
        if(col.gameObject.tag=="bullet"){
             Debug.Log("Collided");
             counter-=1;
             Destroy(col.gameObject);
        }
        if (counter==0)
        {
            Destroy(gameObject);
        }
    }
}
