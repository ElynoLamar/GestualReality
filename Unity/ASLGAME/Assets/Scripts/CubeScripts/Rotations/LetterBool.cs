using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letterbool : MonoBehaviour
{
    public Animator _animator;
    public string letter;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void  activateLetter()
    {
        _animator.SetBool("Letter" + letter, true);
    }
}
