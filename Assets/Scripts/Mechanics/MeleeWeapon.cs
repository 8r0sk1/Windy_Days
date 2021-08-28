using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLib;
using DigitalRuby.LightningBolt;

public class MeleeWeapon : MonoBehaviour
{
    public GameObject hitBox;
    public int damage { private set; get; }
    public int damageA;
    public int damageB;
    public int damageC;
    public LightningBoltScript script_lightning;
    public WeaponHitBox weaponHitBox;

    public void Start()
    {
        script_lightning = gameObject.GetComponentInChildren<LightningBoltScript>();
        weaponHitBox = gameObject.GetComponentInChildren<WeaponHitBox>();
    }

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
                //activate lighning particles
                script_lightning.enabled = true;
                
                


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
        script_lightning.EndObject = script_lightning.StartObject;
        script_lightning.enabled = false;
    }
}
