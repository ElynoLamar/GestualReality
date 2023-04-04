using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int cardID;

    private bool isFlipped = false;

    public void Flip()
    {
        if (isFlipped)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        isFlipped = !isFlipped;
    }
}
