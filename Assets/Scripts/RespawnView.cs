using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class RespawnView : MonoBehaviour
{
    public void restartButton() {
        SceneManager.LoadScene(1);
    }

    public void mainMenuButton() {
        SceneManager.LoadScene(0);
    }
}
