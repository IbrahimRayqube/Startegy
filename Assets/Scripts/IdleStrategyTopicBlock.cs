using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleStrategyTopicBlock : MonoBehaviour
{

    // Start is called before the first frame update
    public Color[] allColors;
    private Material blockMaterial;
    bool isMovingAwayFromCamera;
    public float moveSpeed = 1;
    public float forwardSpeed = -1;
    Vector3 moveDirection;
    public bool moveForward;
    public Vector3 upperPosition;
    public Vector3 lowerPosition;
    public bool isGoingup = true;
    bool isHovering = false;
    public float hoveringSpeed = 5f;
    private void Awake()
    {
        SceneController.Instance.idleScreenBlocks.Add(this);
        blockMaterial = GetComponent<Renderer>().material;
        blockMaterial.color = allColors[Random.Range(0, allColors.Length)];
        isGoingup = true;
        //SceneController.onUserDetected += moveAwayFromCamera;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(moveForward)
            transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);
        //if (isMovingAwayFromCamera)
        //{
        //    transform.Translate(new Vector3(moveDirection.x, moveDirection.y, 0) * Time.deltaTime * moveSpeed);
        //}
        
    }

    public void resetMaterial()
    {
        blockMaterial = GetComponent<Renderer>().material;
        blockMaterial.color = allColors[Random.Range(0, allColors.Length)];
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CubeEnd")
        {
            Debug.Log("Triggered");
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 32);
        }
    }


    public void moveAwayFromCamera()
    {
        moveDirection = transform.position - Camera.main.transform.position;
        isMovingAwayFromCamera = true;
    }

    private void OnDestroy()
    {
        //SceneController.onUserDetected -= moveAwayFromCamera;
    }

    public void startHovering()
    {
        Debug.Log("StartHovering called");
        upperPosition = new Vector3(transform.position.x, transform.position.y + Random.Range(0.5f, 1.5f), transform.position.z);
        lowerPosition = new Vector3(transform.position.x, transform.position.y + Random.Range(-1.5f, -0.5f), transform.position.z);
        isHovering = true;
    }
}
