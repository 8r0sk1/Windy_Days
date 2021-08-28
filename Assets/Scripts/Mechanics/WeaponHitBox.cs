using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.LightningBolt;

public class WeaponHitBox : MonoBehaviour
{
    private MeleeWeapon weapon;
    public Collider obj_hit;
    private LightningBoltScript script_lightning;
    public AudioSource cloudSounds;

    // Start is called before the first frame update
    void Start()
    {
        weapon = this.GetComponentInParent<MeleeWeapon>();
        script_lightning = weapon.script_lightning;
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            obj_hit = other;
            other.GetComponent<EnemyManager>().HPsum(-weapon.damage);
            other.GetComponent<Animator>().SetTrigger("hasBeenDamaged");
            //activate audio source
            cloudSounds.Play();
            script_lightning.EndObject = other.gameObject;
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
