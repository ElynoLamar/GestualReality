using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterUbool : MonoBehaviour
{
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("LetterU", true);
    }
}
