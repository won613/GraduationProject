using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float rotationSpeed;
    public Transform relativeTransform;
    public GameObject itemWindow;
    private bool isWindowOpened = false;
    public LayerMask movementMask;
    Vector3 moveDirection;
    public Rigidbody rb;
    public Vector3 cameraPos;
    private Vector3 lookingVector;
    private Vector3 backwardVector;
    private Vector3 leftVector;
    private Vector3 rightVector;
    private float frontAngle;
    public float maxSpeed;
    public float increaseSpeed;
    private bool isMoveKeyPressing = false;
    private bool isWSKeyPressing = false;
    public bool haveBow = false;
    public GameObject holdingBow;

    public GameObject arrow;
    public GameObject shootPosition;
    private float shotCooldown = 0;
    private bool canShot = true;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        moveSpeed = 0f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        cameraPos = Camera.main.transform.position;
        lookingVector =  transform.position - cameraPos;
        lookingVector.Normalize();
        lookingVector = new Vector3(lookingVector.x, 0, lookingVector.z);
        Quaternion horizontalAngle = Quaternion.Euler(0, 90f, 0);
        backwardVector = -lookingVector;
        rightVector = horizontalAngle * lookingVector;
        leftVector = -rightVector;
        
        frontAngle = Mathf.Atan2(lookingVector.x, lookingVector.z) * Mathf.Rad2Deg;
        Quaternion rotationFrontAngle = Quaternion.AngleAxis(frontAngle, Vector3.up);
        Quaternion rotationBackAngle = Quaternion.AngleAxis(frontAngle + 180f, Vector3.up);
        Quaternion rotationRightAngle = Quaternion.AngleAxis(frontAngle + 90f, Vector3.up);
        Quaternion rotationLeftAngle = Quaternion.AngleAxis(frontAngle - 90f, Vector3.up);
        Quaternion rotationFrontRightAngle = Quaternion.AngleAxis(frontAngle + 45f, Vector3.up);
        Quaternion rotationBackRightAngle = Quaternion.AngleAxis(frontAngle + 135f, Vector3.up);
        Quaternion rotationBackLeftAngle = Quaternion.AngleAxis(frontAngle - 135f, Vector3.up);
        Quaternion rotationFrontLeftAngle = Quaternion.AngleAxis(frontAngle - 45f, Vector3.up);

        if (Input.GetKey(KeyCode.W))
        {
            isMoveKeyPressing = true;
            isWSKeyPressing = true;
            transform.position += lookingVector * moveSpeed * Time.deltaTime;          
            transform.rotation = rotationFrontAngle;
            
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += leftVector * moveSpeed * Time.deltaTime;
                transform.rotation = rotationFrontLeftAngle;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.position += rightVector * moveSpeed * Time.deltaTime;
                transform.rotation = rotationFrontRightAngle;
            }
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            isMoveKeyPressing = false;
            isWSKeyPressing = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            isMoveKeyPressing = true;
            isWSKeyPressing = true;
            transform.position += backwardVector * moveSpeed * Time.deltaTime;           
            transform.rotation = rotationBackAngle;

            if (Input.GetKey(KeyCode.A))
            {
                transform.position += leftVector * moveSpeed * Time.deltaTime;
                transform.rotation = rotationBackLeftAngle;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.position += rightVector * moveSpeed * Time.deltaTime;
                transform.rotation = rotationBackRightAngle;
            }
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            isMoveKeyPressing = false;
            isWSKeyPressing = false;
        }


        if (Input.GetKey(KeyCode.A) && isWSKeyPressing == false)
        {
            isMoveKeyPressing = true;
            transform.position += leftVector * moveSpeed * Time.deltaTime;            
            transform.rotation = rotationLeftAngle;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            isMoveKeyPressing = false;
        }
        if (Input.GetKey(KeyCode.D) && isWSKeyPressing == false)
        {
            isMoveKeyPressing = true;
            transform.position += rightVector * moveSpeed * Time.deltaTime;            
            transform.rotation = rotationRightAngle;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            isMoveKeyPressing = false;
        }

        if (moveSpeed > maxSpeed)
            moveSpeed = maxSpeed;

        if (moveSpeed < 0)
            moveSpeed = 0;

        if (isMoveKeyPressing)
            moveSpeed += increaseSpeed;
        else
            moveSpeed -= increaseSpeed;

        //moveDirection = Vector3.zero;
        //moveDirection.x = 0f;
        //moveDirection.z = 0f;
        //if (Input.GetKey(KeyCode.W)) moveDirection += relativeTransform.forward;
        //if (Input.GetKey(KeyCode.S)) moveDirection += -relativeTransform.forward;
        //if (Input.GetKey(KeyCode.A)) moveDirection += -relativeTransform.right;
        //if (Input.GetKey(KeyCode.D)) moveDirection += relativeTransform.right;
        //print(relativeTransform.forward);
        //transform.position += moveDirection.normalized * 1.0f * Time.deltaTime;

        //rb.velocity = new Vector3(Input.GetAxis("Horizontal"), rb.velocity.y, Input.GetAxis("Vertical"));
        //if (moveDirection != Vector3.zero)
        //    transform.rotation = Quaternion.LookRotation(moveDirection);
        //transform.LookAt(moveDirection);

        shotCooldown--;

        if (shotCooldown < 0)
            canShot = true;
        else
            canShot = false;

        if (haveBow)
            holdingBow.SetActive(true);

        if (Input.GetKey(KeyCode.Space) && haveBow && canShot)
        {
            ShootArrow();
            canShot = false;
            
        }
            


    }

    void LateUpdate()
    {        

        if (Input.GetMouseButtonDown(1))
        {
            if (isWindowOpened == false)
            {
                itemWindow.SetActive(true);
                isWindowOpened = true;
            }
            else
            {
                itemWindow.SetActive(false);
                isWindowOpened = false;
            }
                
        }
        

    }

    void ShootArrow()
    {        
        var arrowClone = (GameObject)Instantiate(arrow, shootPosition.transform.position, transform.rotation);
        Vector3 vec = transform.rotation.eulerAngles;
        vec.y += 90;        
        arrowClone.transform.rotation = Quaternion.Euler(vec);
        arrowClone.GetComponent<Rigidbody>().velocity = transform.forward * 9;
        shotCooldown = 20f;
        
    }


}
