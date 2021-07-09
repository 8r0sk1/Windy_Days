using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarperLock : MonoBehaviour
{
    public GameObject warper;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
