using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float turnSpeed;
    public float acceleration;
    public float verticalSpeed;

    float moveSpeed;
    private MODE currentMode = MODE.FORWARD;

    internal MODE CurrentMode {
        get {
            return currentMode;
        }

        set {
            currentMode = value;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        GetInput();

        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        if (currentMode != MODE.FORWARD && !Input.GetKey(KeyCode.W) && moveSpeed > 0) {
            moveSpeed -= acceleration * Time.deltaTime;
            if(moveSpeed < 0) {
                moveSpeed = 0;
            }
        }
	}

    void GetInput() {
        if (Input.GetKey(KeyCode.W)) {
            Debug.Log("W held");
            switch (currentMode) {
                case MODE.FORWARD:
                    moveSpeed += acceleration * Time.deltaTime;
                    break;
                case MODE.LEFT:
                    transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
                    break;
                case MODE.RIGHT:
                    transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
                    break;
                case MODE.BACK:
                    moveSpeed -= acceleration * Time.deltaTime;
                    break;
                case MODE.UP:
                    transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime);
                    break;
                case MODE.DOWN:
                    transform.Translate(Vector3.down * verticalSpeed * Time.deltaTime);
                    break;
            }
        }

        if (Input.GetKeyUp(KeyCode.W)) {
            switch (currentMode) {
                case MODE.FORWARD:
                    currentMode = MODE.LEFT;
                    break;
                case MODE.LEFT:
                    currentMode = MODE.RIGHT;
                    break;
                case MODE.RIGHT:
                    currentMode = MODE.BACK;
                    break;
                case MODE.BACK:
                    currentMode = MODE.UP;
                    break;
                case MODE.UP:
                    currentMode = MODE.DOWN;
                    break;
                case MODE.DOWN:
                    currentMode = MODE.FORWARD;
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("FIRE ZHE MIZZILES!!!!");
        }
    }
}

enum MODE {
    FORWARD, LEFT, RIGHT, BACK, UP, DOWN
}
