using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionMenu : MonoBehaviour {
     
    void QuitToMenu() {
        SceneManager.LoadScene(0);
    }
}