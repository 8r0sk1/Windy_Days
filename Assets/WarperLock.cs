using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarperLock : MonoBehaviour
{
    public GameObject warper;

    public void Lock()
    {
        warper.SetActive(false);
    }

    public void Unlock()
    {
        warper.SetActive(true);
    }

    private void OnDisable()
    {
        Unlock();
    }
}
