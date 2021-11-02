using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject targetDirection;

    public float bulletForce;
    private bool isAiming = false;
    private bool isFired = false;

    public void Update()
    {
        if (!isFired)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isAiming = true;
            }

            if (isAiming)
            {
                Aiming();
            }

            if (Input.GetMouseButtonUp(0))
            {
                isAiming = false;
                Shoot();
            }
        }
    }

    private void Aiming()
    {
        targetDirection.SetActive(true);
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Vector3 target = targetDirection.transform.position - transform.position;
        bullet.GetComponent<Rigidbody>().AddForce(target * bulletForce, ForceMode.Impulse);
        targetDirection.SetActive(false);
        isFired = true;
    }

    public void ReloadGun() => isFired = false;



}
