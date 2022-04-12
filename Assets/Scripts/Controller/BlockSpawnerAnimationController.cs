using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnerAnimationController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onAnimationCompleted()
    {
        SceneController.Instance.blocksMovedOnSides();
    }
}
