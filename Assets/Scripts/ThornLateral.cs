using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornLateral : MonoBehaviour {

    public float speed;

    [Header("Path")]
    public Vector3 leftPos;
    public Vector3 rightPos;

    private Vector3 targetPos;
    private int direction; //1 izq 2 der

    private List<Transform> transformsOnIt;

    private void Awake()
    {
        transformsOnIt = new List<Transform>();
    }

    // Use this for initialization
    void Start()
    {
        targetPos = rightPos;
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
            Vector3 desp = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed) - transform.position;
            transform.position += desp;
            foreach (Transform t in transformsOnIt)
            {
                t.position += desp;
            }
            if (transform.position == targetPos)
            {
                if (direction == 1)
                {
                    transform.Rotate(0, 0, 180, Space.World);
                    targetPos = rightPos;
                    direction = 2;
                }
                else
                {
                    transform.Rotate(0, 0, -180, Space.World);
                    targetPos = leftPos;
                    direction = 1;
                }
            }
        
    }

    [ContextMenu("Go to left")]
    private void PosInInitial()
    {
        transform.position = leftPos;
    }

    [ContextMenu("Go to right")]
    private void PosInFinal()
    {
        transform.position = rightPos;
    }

    [ContextMenu("Set as right")]
    private void SetAsRight()
    {
        rightPos = transform.position;
    }

    [ContextMenu("Set as left")]
    private void SetAsLeft()
    {
        leftPos = transform.position;
    }
}
