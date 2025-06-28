using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject gunPrefab1;
    public GameObject gunPrefab2;
    public Transform human;  // referenca na human objekt

    private GameObject currentGun;

    void Start()
    {
        if (currentGun == null && gunPrefab1 != null)
        {
            currentGun = InstantiateGun(gunPrefab1);
        }
    }

    void Update()
    {
        SwitchWeapon();
    }

    void SwitchWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeGun(gunPrefab1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeGun(gunPrefab2);
        }
    }

    void ChangeGun(GameObject gunPrefab)
    {
        if (currentGun != null)
        {
            Destroy(currentGun);
        }

        currentGun = InstantiateGun(gunPrefab);
    }

    GameObject InstantiateGun(GameObject gunPrefab)
    {
        GameObject gun = Instantiate(gunPrefab, transform.position, Quaternion.identity);
        gun.transform.parent = transform;

        if (human != null)
        {
            Vector3 direction = (human.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);

            Quaternion extraRotation = Quaternion.Euler(0, -90, 0);  

            gun.transform.rotation = lookRotation * extraRotation;
        }

        return gun;
    }
}
