using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public bool gameOver = false;
    private float gameStartTime;

    void Start()
    {
        gameStartTime = Time.time;
    }

    public void endGame()
    {
        float gameTime = Time.time - gameStartTime;
        Debug.Log("Game over! Total game time: " + gameTime.ToString("F2") + " seconds");
        Time.timeScale = 0;
    }
}