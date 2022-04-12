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
    private void Awake()
    {
        SceneController.Instance.idleScreenBlocks.Add(this);
        blockMaterial = GetComponent<Renderer>().material;
        blockMaterial.color = allColors[Random.Range(0, allColors.Length)];
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
        gameObject.AddComponent<TweenPosition>();
        TweenPosition tweener = GetComponent<TweenPosition>();
        tweener.from = transform.position;
        tweener.to = new Vector3(transform.position.x, transform.position.y + Random.Range(0.1f, 0.3f), transform.position.z);
        tweener.style = UITweener.Style.PingPong;
        tweener.delay = Random.Range(0, 1.5f);
        tweener.enabled = true;
        transform.parent = null;
        tweener.PlayForward();
    }
}
