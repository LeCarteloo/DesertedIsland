using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class RespawnView : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void restartButton() {
        SceneManager.LoadScene("SampleScene");
    }

    public void mainMenuButton() {
        SceneManager.LoadScene("MainMenu");
    }
}
