using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animator controlador;
    public float speed = 5f;
    public Vector3 forward;
    public Vector3 right;
    public float cooldownTime = 1.5f;
    public bool onCool;
    public bool reverseGravity;
    public bool isDead;
    public bool allKeysColected;
    public CameraSwitch cameraSwitch;
    public int keysCounter = 0;
    public int keysTotal;
    public float g = 2f;

    Text cooldownText;
    Text keysText;
    Rigidbody rb;
    Quaternion normalRotation;
    Quaternion reverseRotation;


    private float nextUseGravityTime = 0;
    private float startTime;
    private float rotationSpeed = 720;
    private bool isRotating = false;

    void Start()
    {


        rb = GetComponent<Rigidbody>();
        controlador = GetComponent<Animator>();
        transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));

        keysTotal = GameObject.FindGameObjectsWithTag("Key").Length;

        reverseGravity = false;
        onCool = false;
        isDead = false;

        cooldownText = GameObject.Find("Canvas/Gravity Text").GetComponent<Text>();
        keysText = GameObject.Find("Canvas/Keys").GetComponent<Text>();

        cooldownText.text = "Use Gravity";

        if (keysTotal >= 1)
        {
            keysText.text = "Keys: 0/" + keysTotal;
        }
        else if (keysTotal == 0)
        {
            keysText.text = " ";
        }


    }

    void Update()
    {
        this.transform.localScale = new Vector3(1, 1, 1);

        if (isDead == false)
        {
            if (cameraSwitch.controlScheme == 1)
            {
                MoveForwardOnD();
            }
            else if (cameraSwitch.controlScheme == 2)
            {
                MoveForwardOnS();
            }
            else if (cameraSwitch.controlScheme == 3)
            {
                MoveForwardOnA();
            }
            else if (cameraSwitch.controlScheme == 4)
            {
                MoveForwardOnW();
            }
        }

        if (Time.time > nextUseGravityTime)
        {
            onCool = false;
            if (Input.GetKeyDown("space"))
            {
                controlador.SetBool("Jump", true);
                isRotating = true;
                nextUseGravityTime = Time.time + cooldownTime;
                StartCoroutine(WaitToSetJumpAsFalse());
            }
            else if (Time.time < nextUseGravityTime)
            {
                onCool = true;
            }
        }

        if (Input.GetKey("escape") && isDead)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (keysCounter == keysTotal)
        {
            allKeysColected = true;
        }

        GravityTextChange();
        rb.AddForce(g * Physics.gravity, ForceMode.Acceleration);

    }

    void GravityTextChange()
    {
        if (onCool == false)
        {
            cooldownText.text = "Use Gravity";
        }
        else if (onCool == true)
        {
            cooldownText.text = "On Cooldown";
        }
    }

    IEnumerator Rotate(float yAngle)
    {
        normalRotation = Quaternion.Euler(new Vector3(0, yAngle, 0));
        reverseRotation = Quaternion.Euler(new Vector3(0, yAngle, 180));

        startTime = Time.time;
        //yield return new WaitForSeconds(0.3f);
        if (reverseGravity == true)
        {
            //transform.rotation = Quaternion.Lerp(transform.rotation, playerNormalRotation.rotation, Time.deltaTime);
            while (Time.time - startTime < 0.8f)
            {
                transform.rotation = Quaternion.Lerp(reverseRotation, normalRotation, (Time.time - startTime) * 2);
                yield return null;
            }
            //transform.rotation = normalRotation;
        }
        else if (reverseGravity == false)
        {
            //transform.rotation = Quaternion.Lerp(transform.rotation, playerReverseRotation.rotation, Time.deltaTime);
            while (Time.time - startTime < 0.8f)
            {
                transform.rotation = Quaternion.Lerp(normalRotation, reverseRotation, (Time.time - startTime) * 2);
                yield return null;
            }
            //transform.rotation = reverseRotation;
        }
    }

    void MoveForwardOnD() //camera1
    {

        float xAxis = speed * Time.deltaTime * Input.GetAxis("Horizontal");
        float zAxis = speed * Time.deltaTime * Input.GetAxis("Vertical");


        transform.position += new Vector3(xAxis, 0f, zAxis); //walk controls

        Vector3 movementDirection = new Vector3(xAxis, 0, zAxis);
        if (movementDirection != Vector3.zero)
        {
            controlador.SetBool("Walk", true);

        }
        else if (movementDirection == Vector3.zero)
        {
            controlador.SetBool("Walk", false);
        }

        if (reverseGravity == false)
        {
            if (movementDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
        else if (reverseGravity)
        {
            if (movementDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.down);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }

        if (isRotating)
        {
            if (!isDead)
            {
                float yAngle = transform.eulerAngles.y;// heading detection for rotation
                if (reverseGravity == true)
                {
                    g = -g;
                    GravityTextChange();
                    StartCoroutine(Rotate(yAngle));
                    reverseGravity = false;
                }
                else if (reverseGravity == false)
                {
                    g = -g;
                    GravityTextChange();
                    StartCoroutine(Rotate(yAngle));
                    reverseGravity = true;
                }

                onCool = true;

                isRotating = !isRotating;
            }
        }
    }

    void MoveForwardOnA() //camera3
    {

        float xAxis = speed * Time.deltaTime * Input.GetAxis("Horizontal");
        float zAxis = speed * Time.deltaTime * Input.GetAxis("Vertical");

        transform.position += new Vector3(-xAxis, 0f, -zAxis);

        if (reverseGravity == false)
        {
            Vector3 movementDirection = new Vector3(-xAxis, 0, -zAxis);
            if (movementDirection != Vector3.zero)
            {
                controlador.SetBool("Walk", true);

            }
            else if (movementDirection == Vector3.zero)
            {
                controlador.SetBool("Walk", false);
            }
            if (movementDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
        else if (reverseGravity)
        {
            Vector3 movementDirection = new Vector3(-xAxis, 0, -zAxis);

            if (movementDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.down);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }


        if (isRotating)
        {
            if (!isDead)
            {
                float yAngle = transform.eulerAngles.y;// heading detection for rotation
                if (reverseGravity == true)
                {
                    g = -g;
                    GravityTextChange();
                    StartCoroutine(Rotate(yAngle));
                    reverseGravity = false;
                }
                else if (reverseGravity == false)
                {
                    g = -g;
                    GravityTextChange();
                    StartCoroutine(Rotate(yAngle));
                    reverseGravity = true;
                }

                onCool = true;

                isRotating = !isRotating;
            }

        }
    }

    void MoveForwardOnS() //camera2
    {

        float xAxis = speed * Time.deltaTime * Input.GetAxis("Horizontal");
        float zAxis = speed * Time.deltaTime * Input.GetAxis("Vertical");

        transform.position += new Vector3(-zAxis, 0f, xAxis);

        if (reverseGravity == false)
        {
            Vector3 movementDirection = new Vector3(-zAxis, 0, xAxis);
            if (movementDirection != Vector3.zero)
            {
                controlador.SetBool("Walk", true);

            }
            else if (movementDirection == Vector3.zero)
            {
                controlador.SetBool("Walk", false);
            }
            if (movementDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
        else if (reverseGravity)
        {
            Vector3 movementDirection = new Vector3(-zAxis, 0, xAxis);

            if (movementDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.down);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }

        if (isRotating)
        {
            if (!isDead)
            {
                float yAngle = transform.eulerAngles.y;// heading detection for rotation
                if (reverseGravity == true)
                {
                    g = -g;
                    GravityTextChange();
                    StartCoroutine(Rotate(yAngle));
                    reverseGravity = false;
                }
                else if (reverseGravity == false)
                {
                    g = -g;
                    GravityTextChange();
                    StartCoroutine(Rotate(yAngle));
                    reverseGravity = true;
                }

                onCool = true;

                isRotating = !isRotating;
            }
        }
    }

    void MoveForwardOnW() //camera4
    {
        float xAxis = speed * Time.deltaTime * Input.GetAxis("Horizontal");
        float zAxis = speed * Time.deltaTime * Input.GetAxis("Vertical");

        transform.position += new Vector3(zAxis, 0f, -xAxis);
        if (reverseGravity == false)
        {
            Vector3 movementDirection = new Vector3(zAxis, 0f, -xAxis);
            if (movementDirection != Vector3.zero)
            {
                controlador.SetBool("Walk", true);

            }
            else if (movementDirection == Vector3.zero)
            {
                controlador.SetBool("Walk", false);
            }
            if (movementDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
        else if (reverseGravity)
        {
            Vector3 movementDirection = new Vector3(zAxis, 0f, -xAxis);

            if (movementDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.down);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }

        if (isRotating)
        {
            if (!isDead)
            {
                float yAngle = transform.eulerAngles.y;// heading detection for rotation
                if (reverseGravity == true)
                {
                    g = -g;
                    GravityTextChange();
                    StartCoroutine(Rotate(yAngle));
                    reverseGravity = false;
                }
                else if (reverseGravity == false)
                {
                    g = -g;
                    GravityTextChange();
                    StartCoroutine(Rotate(yAngle));
                    reverseGravity = true;
                }

                onCool = true;

                isRotating = !isRotating;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Death" && !isDead) //Death
        {
            //print("Game Over");
            cameraSwitch.controlScheme = 0; //lock the controls
            isDead = true;
        }

        if (other.gameObject.tag == "Key") //Keys
        {
            keysCounter++;
            keysText.text = $"Keys: {keysCounter}/" + keysTotal;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Camera")
        {
            cameraSwitch.cam1Active = true;
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "Camera2")
        {
            cameraSwitch.cam2Active = true;
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "Camera3")
        {
            cameraSwitch.cam3Active = true;
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "Camera4")
        {
            cameraSwitch.cam4Active = true;
            other.gameObject.SetActive(false);
        }
    }


    IEnumerator WaitToSetJumpAsFalse()
    {
        yield return new WaitForSeconds(0.8f);
        controlador.SetBool("Jump", false);
    }

}