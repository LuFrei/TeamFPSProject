using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TWG.CoreSystems {
public class GameManager: MonoBehaviour {

    public enum GameState { Paused, Running }
    public GameState currentGameState = GameState.Running;

    [SerializeField] private GameObject missionMenu;


    /// <summary>
    /// 
    /// </summary>
    /// <returns>If the menu was accessed last call</returns>
    public bool AccessMenu() {
        if(currentGameState == GameState.Running) {
            currentGameState = GameState.Paused;
            Cursor.lockState = CursorLockMode.None;
            missionMenu.SetActive(true);
            return true;
        }
        currentGameState = GameState.Running;
        Cursor.lockState = CursorLockMode.Locked;
        missionMenu.SetActive(false);
        return false;
    }
}
}