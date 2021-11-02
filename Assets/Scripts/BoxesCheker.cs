using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxesCheker : MonoBehaviour
{
    [SerializeField] private Gun gun;
    public Button rewindButton;

    private int countOfObjectsToRewind;
    private int countOfObjectsPrepare;

    public bool isRedy = false;

    public void Start()
    {
        rewindButton.interactable = false;
        countOfObjectsToRewind = transform.hierarchyCount-1;
    }

    public void AddPrepareBox() 
    {
        Debug.Log("1 : " + countOfObjectsPrepare);
        Debug.Log("2 : " + countOfObjectsToRewind);
        countOfObjectsPrepare++;
        if (countOfObjectsPrepare == countOfObjectsToRewind) 
        {
            isRedy = true;
            rewindButton.interactable = true;
        }
    }


    public void StartRewindInChilds() 
    {
        for (int i = 0; i < countOfObjectsToRewind; i++)
        {
            transform.GetChild(i).GetComponent<TimeObject>().StartRewind();
        }
        StartCoroutine(ReloadGun());
    }
    public void  UnPrepare() 
    {
        countOfObjectsPrepare = 0;
    }

    IEnumerator ReloadGun() 
    {
        yield return new WaitForSeconds(1f);
        gun.ReloadGun();
        yield return new WaitForSeconds(0.3f);
        rewindButton.interactable = false;
    }
}
