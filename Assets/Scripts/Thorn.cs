using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : MonoBehaviour {

    public float speed;
    public int id;
    public bool activate;

    [Header("Path")]
    public Vector3 initialPos;
    public Vector3 finalPos;
    public Vector3 leftPos;
    public Vector3 rightPos;

    private Vector3 targetPos;
    private int direction; //1 izq 2 der
    private bool descend;

    private List<Transform> transformsOnIt;

    private void Awake()
    {
        transformsOnIt = new List<Transform>();
    }

    // Use this for initialization
    void Start () {
        targetPos = finalPos;
        descend = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.parent.GetComponent<ThornParent>().activate)
        {
            if (descend == true)
            {
                Vector3 desp = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed) - transform.position;
                transform.position += desp;
                foreach (Transform t in transformsOnIt)
                {
                    t.position += desp;
                }
                if (transform.position == targetPos)
                {
                    descend = false;
                    if (id % 2 == 0)
                    {
                        transform.Rotate(0, 0, 90, Space.World);
                        targetPos = leftPos;
                        direction = 1;

                    }
                    else
                    {
                        transform.Rotate(0, 0, -90, Space.World);
                        targetPos = rightPos;
                        direction = 2;
                    }
                }
            }
            else
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
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    void OnCollisionExit2D(Collision2D col)
    {

    }

    private void ChangeTargetPosDescend()
    {
        targetPos = targetPos == initialPos ? finalPos : initialPos;
    }

    [ContextMenu("Go to initial")]
    private void PosInInitial()
    {
        transform.position = initialPos;
    }

    [ContextMenu("Go to final")]
    private void PosInFinal()
    {
        transform.position = finalPos;
    }

    [ContextMenu("Set as initial")]
    private void SetAsInitial()
    {
        initialPos = transform.position;
    }

    [ContextMenu("Set as final")]
    private void SetAsFinal()
    {
        finalPos = transform.position;
    }

    [ContextMenu("Set as right")]
    private void SetAsRight()
    {
        leftPos = transform.position;
    }

    [ContextMenu("Set as left")]
    private void SetAsLeft()
    {
        rightPos = transform.position;
    }

}
