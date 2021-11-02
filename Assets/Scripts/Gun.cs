using UnityEngine;
using UnityEngine.EventSystems;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _targetDirection;

    public float _bulletForce;
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
        _targetDirection.SetActive(true);
    }

    private void Shoot()
    {
        GameObject _bulletPart = Instantiate(_bullet, transform.position, Quaternion.identity);
        Vector3 _target = _targetDirection.transform.position - transform.position;
        _bulletPart.GetComponent<Rigidbody>().AddForce(_target * _bulletForce, ForceMode.Impulse);
        _targetDirection.SetActive(false);
        isFired = true;

    }

    public void ReloadGun() => isFired = false;



}
