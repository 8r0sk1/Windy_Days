using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public GameObject hitBox;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableHitbox()
    {
        hitBox.SetActive(true);
    }

    public void DisableHitbox()
    {
        hitBox.SetActive(false);
    }
}
