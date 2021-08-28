using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.LightningBolt;

public class WeaponHitBox : MonoBehaviour
{
    private MeleeWeapon weapon;
    public Collider obj_hit;
    public AudioSource cloudSounds;

    // Start is called before the first frame update
    void Start()
    {
        weapon = this.GetComponentInParent<MeleeWeapon>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            obj_hit = other;
            other.GetComponent<EnemyManager>().HPsum(-weapon.damage);
            other.GetComponent<Animator>().SetTrigger("hasBeenDamaged");
            //activate audio source
            if (weapon.damage == weapon.damageC)
            {
                weapon.script_lightning.EndObject = other.gameObject;
                cloudSounds.Play();
            }
            //DEBUG
            Debug.Log("Hitted " + other);
        }
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerManager>().HPsum(-weapon.damage);
            //DEBUG
            Debug.Log("Hitted " + other);
        }
    }
}
