using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    [Header("Movement")]
    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    public float speed;

    [Header("Camera")]
    [SerializeField]
    private float currentCameraRotation;
    private float cameraRotation;
    [SerializeField]
    private float sensitivity;
    public Camera cam;

    [Header("Jumping")]
    [SerializeField]
    private float jumpForce;
    public bool canJump = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Jumping();
        Rotation();
    }
    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMove;
        Vector3 moveVertical = transform.forward * zMove;

        velocity = (moveVertical + moveHorizontal).normalized * speed;

        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }
    void Rotation()
    {
        float yRot = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0, yRot, 0) * sensitivity;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        float xRot = Input.GetAxisRaw("Mouse Y");
        cameraRotation = xRot * sensitivity;
        if(cam != null)
        {
            currentCameraRotation -= cameraRotation;
            currentCameraRotation = Mathf.Clamp(currentCameraRotation, -90, 90);
            cam.transform.localEulerAngles = new Vector3(currentCameraRotation, 0, 0);
        }
    }
    void Jumping()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(canJump)
            {
                rb.AddForce(Vector3.up * jumpForce * Time.fixedDeltaTime);
                canJump = false;
                Debug.Log("Jumped");
            }
        }
    }
}
