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
    public bool isOnArea = false;

    public AudioSource gravidadeOn;
    public AudioSource gravidadeOff;
    public AudioSource apanha;
    public AudioSource portaAbre;

    Text scoreText;
    Text cooldownText;
    Text keysText;
    Text coolText;
    GameObject OnCool;
    GameObject UseGrav;
    Rigidbody rb;
    Quaternion normalRotation;
    Quaternion reverseRotation;

    private int score = 0;
    private float nextUseGravityTime = 0;
    private float staticCooldownTime;
    private float timeRemaining;
    private float startTime;
    private float rotationSpeed = 720;
    private bool isRotating = false;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        controlador = GetComponent<Animator>();
        transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));

        keysTotal = GameObject.FindGameObjectsWithTag("Key").Length;       

        //cooldownText = GameObject.Find("Canvas/Gravity Text").GetComponent<Text>();
        keysText = GameObject.Find("Canvas/Keys").GetComponent<Text>();
        scoreText = GameObject.Find("Canvas/Score").GetComponent<Text>();
        scoreText.text = "Score: " + score;

        OnCool = GameObject.Find("Canvas/OnCool");
        UseGrav = GameObject.Find("Canvas/UseGrav");
        coolText = GameObject.Find("Canvas/coolText").GetComponent<Text>();
        //cooldownText.text = "Use Gravity";

        staticCooldownTime = cooldownTime;
        timeRemaining = staticCooldownTime;

        reverseGravity = false;
        onCool = false;
        isDead = false;

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

        if (isDead == false) //esquema de controlo
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

        if (Input.GetKey("return") && isDead)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (keysCounter == keysTotal)
        {
            allKeysColected = true;
        }

        GravityTextChange();
        rb.AddForce(g * Physics.gravity, ForceMode.Acceleration);


        if (Input.GetKey("space") && !isDead)
        {
            if (onCool == false)
            {
                if (reverseGravity == true)
                {
                    gravidadeOff.Play();
                }

                else if (reverseGravity == false)
                {
                    gravidadeOn.Play();
                }
            }
        }
    }

    void GravityTextChange()
    {
        if (onCool == false)
        {
            OnCool.SetActive(false);
            UseGrav.SetActive(true);
            //cooldownText.text = "Use Gravity";
            timeRemaining = staticCooldownTime;
            coolText.gameObject.SetActive(false);
        }
        else if (onCool == true)
        {
            OnCool.SetActive(true);
            UseGrav.SetActive(false);

            timeRemaining -= Time.deltaTime;
            coolText.gameObject.SetActive(true);
            DisplayTime(timeRemaining);
            //cooldownText.text = "On Cooldown";
        }
    }

    void DisplayTime(float timeToDisplay){
        //timeToDisplay += 1;
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = (timeToDisplay % 1) * 1000;
        coolText.text = string.Format("{0:0}:{1:000}", seconds, milliseconds);
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

        else if (other.gameObject.tag == "Enemy" && !isDead)
        {
            cameraSwitch.controlScheme = 0;
            isDead = true;
        }

        if (other.gameObject.tag == "Key") //Keys
        {
            keysCounter++;
            keysText.text = $"Keys: {keysCounter}/" + keysTotal;
            other.gameObject.SetActive(false);
            apanha.Play();
            score += 10;
            scoreText.text = "Score: " + score;
        }

        if (other.gameObject.tag == "Area") //Area
        {
            isOnArea = true;
        }

        if (other.gameObject.tag == "Camera")
        {
            cameraSwitch.cam1Active = true;
            other.gameObject.SetActive(false);
            apanha.Play();
            score += 5;
            scoreText.text = "Score: " + score;
        }
        else if (other.gameObject.tag == "Camera2")
        {
            cameraSwitch.cam2Active = true;
            other.gameObject.SetActive(false);
            apanha.Play();
            score += 5;
            scoreText.text = "Score: " + score;
        }
        else if (other.gameObject.tag == "Camera3")
        {
            cameraSwitch.cam3Active = true;
            other.gameObject.SetActive(false);
            apanha.Play();
            score += 5;
            scoreText.text = "Score: " + score;
        }
        else if (other.gameObject.tag == "Camera4")
        {
            cameraSwitch.cam4Active = true;
            other.gameObject.SetActive(false);
            apanha.Play();
            score += 5;
            scoreText.text = "Score: " + score;
        }
    }

    void OnTriggerExit(Collider other){
            if(other.gameObject.tag == "Area"){
                isOnArea = false;
            }
            
    }

    IEnumerator WaitToSetJumpAsFalse()
    {
        yield return new WaitForSeconds(0.8f);
        controlador.SetBool("Jump", false);
    }

}