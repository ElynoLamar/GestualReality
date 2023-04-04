using System;
using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;


public class CardFlip : MonoBehaviour
{
    public GameObject[] cards;
    public int[] cardIDs;
    public float visibleDistance = 5f;

    private int currentCardIndex = -1;
    private int currentCardID = -1;
    private bool isFlipping = false;

    private void Start()
    {
        for (int i = 0; i < cardIDs.Length; i++)
        {
            cards[i].GetComponent<Card>().cardID = cardIDs[i];
        }
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position,
            Camera.main.transform.position);

        if (!isFlipping && distanceToPlayer <= visibleDistance)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.GetComponent<Card>() != null)
                {
                    int cardID = hit.collider.gameObject.GetComponent<Card>().cardID;
                    if (currentCardID == -1)
                    {
                        currentCardIndex = Array.IndexOf(cardIDs, cardID);
                        currentCardID = cardID;
                        cards[currentCardIndex].GetComponent<Card>().Flip();
                    }
                    else if (currentCardID == cardID && currentCardIndex != Array.IndexOf(cardIDs, cardID))
                    {
                        int matchedCardIndex = Array.IndexOf(cardIDs, cardID);
                        cards[matchedCardIndex].GetComponent<Card>().Flip();
                        currentCardIndex = -1;
                        currentCardID = -1;
                    }
                    else
                    {
                        isFlipping = true;
                        StartCoroutine(FlipBack(currentCardIndex, Array.IndexOf(cardIDs, currentCardID)));
                        currentCardIndex = -1;
                        currentCardID = -1;
                    }
                }
            }
        }
    }

    IEnumerator FlipBack(int cardIndex1, int cardIndex2)
    {
        yield return new WaitForSeconds(1f);
        cards[cardIndex1].GetComponent<Card>().Flip();
        cards[cardIndex2].GetComponent<Card>().Flip();
        isFlipping = false;
    }
}
