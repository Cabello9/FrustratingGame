using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTile : MonoBehaviour {

    public float speed;
    public bool activate;

    [Header("Path")]
    public Vector3 initialPos;
    public Vector3 finalPos;
    public Vector3 mediumPos;

    private Vector3 targetPos;
    private List<Transform> transformsOnIt;

    // Use this for initialization
    void Start () {
        transformsOnIt = new List<Transform>();
        targetPos = finalPos;
        activate = false;
        speed = 3;
    }
	
	// Update is called once per frame
	void Update () {

        if (activate)
        {
            Vector3 desp = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed) - transform.position;
            transform.position += desp;
            foreach (Transform t in transformsOnIt)
            {
                t.position += desp;
            }

            if (transform.position.y > mediumPos.y)
            {
                speed = 3;
            }
        }

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

    [ContextMenu("Set as medium")]
    private void SetAsMedium()
    {
        mediumPos = transform.position;
    }
}
