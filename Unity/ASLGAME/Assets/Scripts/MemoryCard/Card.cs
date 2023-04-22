using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public string color;
    public bool isFlipped = false;
    private GameManagerScript gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManagerScript>();

    }

    private void OnMouseDown()
    {
        bool CubeShow = gameManager.getShowCube();
        //Debug.Log(CubeShow);
        if (!CubeShow)
        {
            if (!isFlipped && gameManager.canFlip)
            {
                FlipCard();
                gameManager.AddCardToSelected(this);
            }
        }

    }

    public void FlipCard()
    {

        isFlipped = true;
        transform.Rotate(0, 180, 0);
    }

    public void UnflipCard()
    {
        isFlipped = false;
        transform.Rotate(0, 180, 0);
        //transform.Rotate(Vector3.right, 180);
    }

    public void SetMatched()
    {
        gameObject.tag = "Matched";

    }
}
