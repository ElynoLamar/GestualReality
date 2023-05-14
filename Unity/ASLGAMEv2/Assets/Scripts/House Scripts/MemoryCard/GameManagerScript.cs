using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    public List<Card> selectedCards = new List<Card>();
    public bool canFlip = true;
    public int score = 0;

    public GameObject CubeE;
    public GameObject CubeI;
    public GameObject CubeU;

    public bool CubeShow;

    //public string tagToFind = "Matched";
    //public bool openDoor = false;

    public void AddCardToSelected(Card card)
    {

        selectedCards.Add(card);
        if (selectedCards.Count == 2)
        {
            canFlip = false;
            StartCoroutine(CheckMatch());
        }

    }



    private IEnumerator CheckMatch()
    {
        if (selectedCards[0].color == selectedCards[1].color)
        {
            yield return new WaitForSeconds(1.0f);
            this.ShowCube(selectedCards[0], selectedCards[1], selectedCards[0].color);
            //selectedCards[0].SetMatched();
            //selectedCards[1].SetMatched();

            score++;


        }
        else
        {
            yield return new WaitForSeconds(1.0f);
            selectedCards[0].UnflipCard();
            selectedCards[1].UnflipCard();
            selectedCards.Clear();

        }
        //selectedCards.Clear();
        canFlip = true;


        //GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Matched");
        //if (objectsWithTag.Length == 6)
        //{
        //    Debug.Log(openDoor);
        //    openDoor = true;
        //}

    }

    private void ShowCube(Card card_A, Card card_B, string color)
    {
        card_B.SetMatched();
        card_A.SetMatched();

        CubeShow = true;


        if (color == "E")
        {
            CubeE.SetActive(true);




        }
        else if (color == "I")
        {
            CubeI.SetActive(true);



        }
        else if (color == "U")
        {
            CubeU.SetActive(true);



        }

    }
    public bool getShowCube()
    {
        return CubeShow;
    }
    public void SetShowCube()
    {
        CubeShow = !CubeShow;
        if (!CubeShow)
        {
            selectedCards.Clear();
        }

    }
    public void UnFlippedSelectedCards()
    {
        //Debug.Log(selectedCards);
        selectedCards[0].UnflipCard();
        selectedCards[1].UnflipCard();
        CubeE.SetActive(false);
        CubeI.SetActive(false);
        CubeU.SetActive(false);
        CubeShow = false;
        selectedCards.Clear();
    }

    public void setCompleted(string Letter)
    {
        if(Letter == "E")
        {
            CubeE.GetComponent<CubeInteraction>().SetCompleted();
        }
        if (Letter == "I")
        {
            CubeI.GetComponent<CubeInteraction>().SetCompleted();
        }
        if (Letter == "U")
        {
            CubeU.GetComponent<CubeInteraction>().SetCompleted();
        }
    }

    public void SetIncompleted(string Letter)
    {
        if (Letter == "E")
        {
            CubeE.GetComponent<CubeInteraction>().SetIncompleted();
        }
        if (Letter == "I")
        {
            CubeI.GetComponent<CubeInteraction>().SetIncompleted();
        }
        if (Letter == "U")
        {
            CubeU.GetComponent<CubeInteraction>().SetIncompleted();
        }
    }
}