using UnityEngine;

public class HumanShoot : MonoBehaviour
{
    [SerializeField] private float damage = 1.0f;
    [SerializeField] private Transform crossHair;
    [SerializeField] private Transform shootPosition; // Where bullets would be spawned

    [SerializeField] private float distance = 100f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Shoot();
        }
            
    }

    void Shoot()
    {
        Ray ray = new Ray(shootPosition.position, shootPosition.forward);
        RaycastHit hit;
        Debug.Log("Pucaj");
        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.collider.CompareTag("enemy"))
            {
                //Destroy(hit.collider.gameObject);
                Debug.Log("Kill");
            }
            else
            {
                Debug.Log("Missed");
            }
        }
    }
}
