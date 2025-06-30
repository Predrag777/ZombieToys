using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] Camera mainCamera;

    public Camera player1Camera;
    private GameObject selected;

    public GameObject res1;
    public GameObject res2;
    public GameObject res3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW");
    }


   void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f))
            {

                if (hitInfo.transform.gameObject.name == "Boy")
                {
                    Destroy(player2);

                    mainCamera.gameObject.SetActive(false);
                    mainCamera.GetComponent<AudioListener>().enabled = false;

                    player1Camera.gameObject.SetActive(true);
                    player1Camera.GetComponent<AudioListener>().enabled = true;

                    player1.GetComponent<HumanMove>().enabled = true;
                    player1.GetComponent<HumanShoot>().enabled = true;


                    // Activate respawner fields
                    res1.SetActive(true);// = true;
                    res2.SetActive(true);// = true;
                    res3.SetActive(true);// = true;
                    
                }

                else if (hitInfo.transform.gameObject.name == "Girl")
                {

                }
            }
        }
    }

}
