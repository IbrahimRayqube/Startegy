using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : Singleton<SceneController>
{
    //public delegate void OnUserDetected();
    //public static event OnUserDetected onUserDetected;
    public List<IdleStrategyTopicBlock> idleScreenBlocks;
    public IdleBlockMover blockMover;
    public GameObject[] hoverers;
    public GameObject picArea;
    public UserProfilePicController picController;
    public MenuController menuController;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            blockMover.speed = 0;
            blockMover.moveBlocks();
            //SceneController.onUserDetected();
            stopBlocks();
        }
    }

    public void stopBlocks()
    {
        foreach(IdleStrategyTopicBlock e in idleScreenBlocks)
        {
            e.moveForward = false;
        }
    }

    public void blocksMovedOnSides()
    {
        //HoverBlocks
        foreach (IdleStrategyTopicBlock e in idleScreenBlocks)
        {
            e.startHovering();
            //e.transform.parent = null;
        }
    }

    // Show welcome message after user face is detected
    public void showWelcomeMsg()
    {
        
    }

}
