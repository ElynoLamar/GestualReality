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
      // Debug.Log("test");

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

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision);
        if (false){

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

    }

    public void FlipCard()
    {

        isFlipped = true;
        transform.Rotate(0, 180, 0);
    }

    public void setFlipCard()
    {
        bool CubeShow = gameManager.getShowCube();
        if (!CubeShow)
        {
            if (!isFlipped && gameManager.canFlip)
            {
                FlipCard();
                gameManager.AddCardToSelected(this);
            }
        }
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
