using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public  class   menuManager : MonoBehaviour
{
    public Button playbtn,volume,level,back;
    public Image soundon,soundoff;
    private bool muted;

    // Start is called before the first frame update
    void Start()
    {
        back.gameObject.SetActive(false);
         soundoff.gameObject.SetActive(false);
      soundon.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Volume(){
      playbtn.gameObject.SetActive(false);
      volume.gameObject.SetActive(false);
      level.gameObject.SetActive(false);
      back.gameObject.SetActive(true);
      soundoff.gameObject.SetActive(true);
      soundon.gameObject.SetActive(true);

    }
    public void Back(){
      playbtn.gameObject.SetActive(true);
      volume.gameObject.SetActive(true);
      level.gameObject.SetActive(true);
      back.gameObject.SetActive(false);
      soundoff.gameObject.SetActive(false);
      soundon.gameObject.SetActive(false);

    }
    public void OnButtonSoundOn(){
          AudioListener.pause=false;
    }
    public void OnButtonSoundOff(){
        AudioListener.pause=true;
    }
    public void Play(){
      SceneManager.LoadScene(1);
    }
}
