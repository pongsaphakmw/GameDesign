using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    // Start is called before the first frame update
    public int gameStartScene;

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameStartScene);
        Time.timeScale = 1f;
    }
    // Create public function to go back to previous scene
}
