using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Platform : MonoBehaviour 
{
    public bool activated;
    public float speed;

    [Header("Path")]
    public Vector3 inititalPos;
    public Vector3 finalPos;
    private Vector3 targetPos;

    private List<Transform> transformsOnIt;

    void Awake()
    {
        transformsOnIt = new List<Transform>();
    }

    void Start()
    {
        targetPos = finalPos;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        transformsOnIt.Add(col.gameObject.transform);
    }

    void OnCollisionExit2D(Collision2D col)
    {
        transformsOnIt.RemoveAll(t => t == col.gameObject.transform);
    }

    void Update()
    {
        if (activated)
        {
            Vector3 desp = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed) - transform.position;
            transform.position += desp;
            foreach (Transform t in transformsOnIt)
            {
                t.position += desp;
            }
            if (transform.position == targetPos)
            {
                ChangeTargetPos();
            }
        }
    }

    public void TurnActivate(bool on)
    {
        activated = on;
    }

    private void ChangeTargetPos()
    {
        targetPos = targetPos == inititalPos ? finalPos : inititalPos;
    }

    [ContextMenu("Go to initial")]
    private void PosInInitial()
    {
        transform.position = inititalPos;
    }

    [ContextMenu("Go to final")]
    private void PosInFinal()
    {
        transform.position = finalPos;
    }

    [ContextMenu("Set as initial")]
    private void SetAsInitial()
    {
        inititalPos = transform.position;
    }

    [ContextMenu("Set as final")]
    private void SetAsFinal()
    {
        finalPos = transform.position;
    }
}
