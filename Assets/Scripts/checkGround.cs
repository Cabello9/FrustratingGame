using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGround : MonoBehaviour {

    private PlayerController characterController;

	// Use this for initialization
	void Start () {
        characterController = GetComponentInParent<PlayerController>();
	}

    void OnCollisionStay2D(Collision2D collision)
    {
        characterController.ground = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(characterController.rb2d.velocity.y > 1)
            characterController.ground = false;
    }
}
