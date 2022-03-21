using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playercontroller : MonoBehaviour
{
    private Rigidbody playerrb;
    public float xbound=12;
    public GameObject bullet;
    public int lifecounter=3;
    public Text life,gameover;
    public Button restart;
    // Start is called before the first frame update
    void Start()
    {
        playerrb=GetComponent<Rigidbody>();
        life.text="Life :"+lifecounter;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)){
           GameObject bulletprefab=Instantiate(bullet,new Vector3(transform.position.x,transform.position.y+0.5f,transform.position.z+1),bullet.transform.rotation);
           Rigidbody bulletrb=bulletprefab.GetComponent<Rigidbody>();
           bulletrb.AddForce(Vector3.forward*15,ForceMode.Impulse);
        //    if(bulletprefab.gameObject.transform.position.z>=5){
        //        Debug.Log("destroy");
        //        Destroy(bulletprefab);
        //    }
        }
        Movement();
    
    }
    public void Movement(){
       var horizontal=Input.GetAxis("Horizontal");
       transform.Translate(Vector3.right*50*horizontal*Time.deltaTime);
      
        if(transform.position.x>=xbound){
            transform.position=new Vector3(xbound,transform.position.y,transform.position.z);
            playerrb.velocity=Vector3.zero;
        }
       if(transform.position.x<=-xbound){
            transform.position=new Vector3(-xbound,transform.position.y,transform.position.z);
              playerrb.velocity=Vector3.zero;
        }
    }
    public void OnCollisionEnter(Collision col){
        if(col.gameObject.tag=="enmbult"){
          lifecounter-=1;
          life.text="Life :"+lifecounter;
          Destroy(col.gameObject);
        }
        
        if (lifecounter==0)
        {
            Die();
        }
    }
    public void Die(){
        Destroy(gameObject);
        Time.timeScale=0;
        gameover.text="Game Over";
        restart.gameObject.SetActive(true);
    }
   
}
