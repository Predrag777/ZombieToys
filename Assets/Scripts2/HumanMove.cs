using UnityEngine;

public class HumanMove : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float rotationSpeed = 20f; // Mouse sensivity


    // private Rigidbody rb;
    private Animator animator;
    [SerializeField] private Transform cameraHolder;

    private float rotationX=0f;//Rotate pplayer by X coordinate


    void Awake()
    {
        /*cameraHolder = GameObject.Find("MainCamera").transform;
        if (cameraHolder == null)
        {
            Debug.LogError("No camer holder");
        }*/
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        // rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        CameraRotation();
    }



    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical); //Define vector with X(horizontal), Y(0f), Z(vertical)

        if (direction != Vector3.zero)
        {
            transform.Translate(direction * speed * Time.deltaTime);
            //    animator.Play("Move");
        }
        animator.SetFloat("speed", direction.magnitude);
    }

    void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -60f, 60f);
        cameraHolder.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX); // Vector3.up is Vector3(0, 1, 0)
    }
}
