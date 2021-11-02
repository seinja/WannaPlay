using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class BoxesCheker : MonoBehaviour
{
    [SerializeField] private Slider coundDownSlider;

    [SerializeField] private Gun gun;
    [SerializeField] private GameObject rewindButton;

    private int countOfObjectsToRewind;
    private int countOfObjectsPrepare;

    private bool isRewindNow;

    public void Start()
    {
        InitCoundDownSlider();
        
        rewindButton.SetActive(false);
        countOfObjectsToRewind = transform.hierarchyCount;
    }

    public void FixedUpdate()
    {
        if (coundDownSlider.value > 0 && isRewindNow) 
        {
            coundDownSlider.value -= Time.fixedDeltaTime;
        }
    }

    public void StartRewindInChilds()
    {
        coundDownSlider.value = transform.GetChild(0).GetComponent<TimeObject>().GetRecordTime;
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
        isRewindNow = false;
        coundDownSlider.value = coundDownSlider.maxValue;
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
        isRewindNow = true;
        for (int i = 0; i < countOfObjectsToRewind - 1; i++)
        {
            transform.GetChild(i).GetComponent<Box>().StopAllCoroutines();
        }
    }

    private void InitCoundDownSlider() 
    {
        coundDownSlider.maxValue = transform.GetChild(0).GetComponent<TimeObject>().GetRecordTime;
        coundDownSlider.value = coundDownSlider.maxValue;
    }

    
}
