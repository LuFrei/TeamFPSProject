using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public enum GameState { Paused, Running}
    public GameState currentGameState = GameState.Running;


    public void ChangeGameState() {
        if(currentGameState == GameState.Running) {
            currentGameState = GameState.Paused;
            Cursor.lockState = CursorLockMode.None;
        }
        currentGameState = GameState.Running;
        Cursor.lockState = CursorLockMode.Locked;
    }
}