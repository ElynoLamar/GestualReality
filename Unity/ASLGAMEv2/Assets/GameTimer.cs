using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameTimer : MonoBehaviour
{
    public bool gameOver = false;
    private float gameStartTime;
    public TMP_Text endText;

    void Start()
    {
        gameStartTime = Time.time;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            endGame();
        }
    }
    public void endGame()
    {
        float gameTime = Time.time - gameStartTime;
        endText.text = "Game over! Total game time: " + gameTime.ToString("F2") + " seconds";
        Time.timeScale = 0;
    }
}