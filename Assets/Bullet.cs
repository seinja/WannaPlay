using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(RemoveBullet());
    }

     IEnumerator RemoveBullet() 
    {
        yield return new WaitForSecondsRealtime(2f);
        Destroy(this.gameObject);
    }
    
}
