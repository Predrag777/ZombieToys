using UnityEngine;

public class ZombieRespawner : MonoBehaviour
{
    [SerializeField] GameObject hellephantPrefab;
    [SerializeField] GameObject zombearPrefab;
    [SerializeField] GameObject zombunniPrefab;

    [SerializeField] private int numZombies=4;


    float coolDown = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int currZombieNums = GameObject.FindGameObjectsWithTag("enemy").Length;
        if (currZombieNums < 4)
        {
            if (coolDown <= 0f)
            {
                Instantiate(hellephantPrefab, transform.position, Quaternion.identity);
                coolDown = 3f;
            }
            coolDown -= Time.deltaTime;
        }
    }
}
