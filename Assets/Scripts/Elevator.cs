using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {

        GetComponent<Collider2D>().enabled = false;

        this.transform.parent.GetComponent<ElevatorTile>().activate = true;

    }
}
