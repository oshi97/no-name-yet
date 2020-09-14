using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
  private CharacterController controller;
  public float speed = 0.3f;
  // Start is called before the first frame update
  // private Vector3 destination;
  void Start () {
    controller = gameObject.AddComponent<CharacterController>();
  }

  void UpdateRotationAndMove () {
    Vector3 mousePos = Input.mousePosition;
    float mouseX = mousePos.x;
    float mouseY = mousePos.y;
    float xOffset = (Screen.width / 2 - mouseX) / (Screen.width / 2);
    float yOffset = (Screen.height / 2 - mouseY) / (Screen.height / 2);
    transform.rotation = new Quaternion(yOffset, -xOffset, 0.0f, 1);
    float moveX = Input.GetAxis("Horizontal") * speed;
    float moveZ = Input.GetAxis("Vertical") * speed;
    Vector3 movement = transform.rotation * new Vector3(moveX, 0.0f, moveZ);
    controller.Move(new Vector3(movement.x, 0.0f, movement.z));
  }

  // Update is called once per frame
  void Update () {
    UpdateRotationAndMove();
  }
}