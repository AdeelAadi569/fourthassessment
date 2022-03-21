using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detectcollision : MonoBehaviour
{
    private static int counter=0;
    private Text score;

    // Start is called before the first frame update
    void Start()
    {
        score=(Text) GameObject.FindGameObjectWithTag("score").GetComponent<Text>();
        score.text="Score :"+counter;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision col){
        if(col.gameObject.tag=="bullet"){
            Debug.Log("collided");
            Destroy(gameObject);
            Destroy(col.gameObject);
            counter+=10;
            score.text="Score :"+counter;
        }
    }
}
