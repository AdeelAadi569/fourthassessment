using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class spawnmanager : MonoBehaviour
{
    public GameObject enemy,pos,bigenemy,bigenmpos,enemybullet,egg;
    private GameObject player;
    public Button pause,restart,resume;
    private int enemycounter;
    private static int wavenumber=4;
    public bool spawnsmalenemy=true,bigenemybool=false,rightbol,leftbol;
    Vector3 startpos;
    
    // Start is called before the first frame update
    void Start()
    {
        startpos=pos.transform.position;
       // SpawnEnemy(wavenumber);
        player=GameObject.Find("player");
       
        //Invoke(SpawnEnemy(wavenumber),2);
    }

    // Update is called once per frame
    void Update()
    {
         enemycounter=GameObject.FindGameObjectsWithTag("enemy").Length;
         if(enemycounter==0 && spawnsmalenemy==true){
             pos.transform.position=startpos;
             Debug.Log("again spawn");
             SpawnEnemy(wavenumber);
             wavenumber+=1;
         }
         if(wavenumber==6){
             spawnsmalenemy=false;
              bigenemybool=true;
              if (enemycounter==0 && bigenemybool==true)
             {
                 SpawnBigEnemy();
                 InvokeRepeating("SPawnBigEnemyBullet",0,2);
             } 
         }
    }
    public void SpawnEnemy(int wave){
        for(int i=0;i<=wave;i++){
       Instantiate(enemy,pos.transform.position,enemy.transform.rotation);
       GameObject prefab=Instantiate(egg,new Vector3(pos.transform.position.x,pos.transform.position.y,pos.transform.position.z-2),egg.transform.rotation);
       Rigidbody rbprefab=prefab.GetComponent<Rigidbody>();
       rbprefab.AddForce(Vector3.back*8,ForceMode.Impulse);
       pos.transform.position=new Vector3(pos.transform.position.x+4,pos.transform.position.y,pos.transform.position.z);
       bigenemybool=false;
       
        }

    }
    public void SpawnBigEnemy(){
        rightbol=true;
       Debug.Log("big enemy spawn");
       if(bigenemybool==true){
            bigenemybool=false;
            for(int j=1;j<=1;j++){
           GameObject bigenemyprefab= Instantiate(bigenemy,bigenmpos.transform.position,bigenemy.transform.rotation);
           Rigidbody rbbigenemy=bigenemyprefab.GetComponent<Rigidbody>();
           if(rightbol==true){
           rbbigenemy.AddForce(Vector3.right,ForceMode.Impulse); 
           }
           if(rbbigenemy.transform.position.x>12){
             leftbol=true;
             rightbol=false;
           }
           if(leftbol==true){
              rbbigenemy.AddForce(Vector3.left*3,ForceMode.Impulse);  
           }
            }
       }
    }
    public void SPawnBigEnemyBullet(){
        GameObject enemybulletprefab= Instantiate(enemybullet,new Vector3(bigenmpos.transform.position.x,bigenmpos.transform.position.y,bigenmpos.transform.position.z-2),enemybullet.transform.rotation);
       Rigidbody rbenemyprefab=enemybulletprefab.GetComponent<Rigidbody>();
       rbenemyprefab.AddForce(Vector3.back*5,ForceMode.Impulse); 
    }
    public void Pause(){
        Time.timeScale=0;
        pause.gameObject.SetActive(false);
        resume.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
    }
    public void Resume(){
        Time.timeScale=1;
        pause.gameObject.SetActive(true);
        resume.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
    }
    public void Restart(){
        Time.timeScale=1;
        SceneManager.LoadScene(1);
       
    }
    
}
