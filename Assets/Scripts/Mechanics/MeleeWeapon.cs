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
    public int damageC;

    public void EnableHitbox(attack_type attack)
    {
        switch (attack) {
            case attack_type.slash1:
                damage = damageA;
                break;
            case attack_type.slash2:
                damage = damageB;
                break;
            case attack_type.special:
                damage = damageC;
                break;
        }

        hitBox.SetActive(true);
    }

    public void EnableHitbox()
    {
        damage = damageA;
        hitBox.SetActive(true);
    }

    public void DisableHitbox()
    {
        hitBox.SetActive(false);
    }
}
