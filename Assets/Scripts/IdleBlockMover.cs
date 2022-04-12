using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBlockMover : MonoBehaviour
{
    public float speed;
    public Animator blockAnimator;
    public bool shouldMove = false;
    public Vector3 initPosition;
    // Start is called before the first frame update

    public void Awake()
    {
        
    }
    void Start()
    {
        blockAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(shouldMove)
        //    transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public void moveBlocks()
    {
        blockAnimator.enabled = true;
        blockAnimator.SetTrigger("move");
    }
}
