using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BoxesCheker : MonoBehaviour
{
    [SerializeField] private Gun gun;
    public Button rewindButton;

    private int countOfObjectsToRewind;
    private int countOfObjectsPrepare;

    public void Start()
    {
        rewindButton.interactable = false;
        countOfObjectsToRewind = transform.hierarchyCount - 1;
    }

    public void AddPrepareBox()
    {
        countOfObjectsPrepare++;
        if (countOfObjectsPrepare == countOfObjectsToRewind)
        {
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
    public void UnPrepare()
    {
        countOfObjectsPrepare = 0;
    }

    IEnumerator ReloadGun()
    {
        yield return new WaitForSeconds(1f);
        gun.ReloadGun();
        rewindButton.interactable = false;
    }
}
