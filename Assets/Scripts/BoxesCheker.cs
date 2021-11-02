using System.Collections;
using UnityEngine;

public class BoxesCheker : MonoBehaviour
{
    [SerializeField] private Gun gun;
    [SerializeField] private GameObject rewindButton;

    private int countOfObjectsToRewind;
    private int countOfObjectsPrepare;

    public void Start()
    {
        rewindButton.SetActive(false);
        countOfObjectsToRewind = transform.hierarchyCount;
    }

    public void StartRewindInChilds()
    {
        for (int i = 0; i < countOfObjectsToRewind - 1; i++)
        {
            transform.GetChild(i).GetComponent<TimeObject>().StartRewind();
        }
        StartCoroutine(ReloadGun());
    }

    IEnumerator ReloadGun()
    {
        StopCoroutineInChildrens();
        rewindButton.SetActive(false);
        yield return new WaitForSeconds(transform.GetChild(0).GetComponent<TimeObject>().GetRecordTime);
        gun.ReloadGun();
    }

    public void StartCheckChild()
    {
        for (int i = 0; i < countOfObjectsToRewind - 1; i++)
        {
            transform.GetChild(i).GetComponent<Box>().StartCoroutine(
                transform.GetChild(i).GetComponent<Box>().CheckStation());
        }
    }
    public void AddPrepareBox()
    {
        countOfObjectsPrepare++;
        if (countOfObjectsPrepare == countOfObjectsToRewind)
        {
            rewindButton.SetActive(true);
        }
    }
    public void UnPrepare()
    {
        countOfObjectsPrepare = 0;
    }

    public void StopCoroutineInChildrens()
    {
        for (int i = 0; i < countOfObjectsToRewind - 1; i++)
        {
            transform.GetChild(i).GetComponent<Box>().StopAllCoroutines();
        }
    }
}
