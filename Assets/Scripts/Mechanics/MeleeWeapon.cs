using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLib;

public class MeleeWeapon : MonoBehaviour
{
    public GameObject hitBox;
    public int damage { private set; get; }
    public int damageA;
    public int damageB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableHitbox(attack_type attack)
    {
        if (attack == attack_type.slash1)
            damage = damageA;
        else if (attack == attack_type.slash2)
            damage = damageB;

        hitBox.SetActive(true);
    }

    public void DisableHitbox()
    {
        hitBox.SetActive(false);
    }
}
