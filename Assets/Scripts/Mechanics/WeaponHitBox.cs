using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitBox : MonoBehaviour
{
    private MeleeWeapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        weapon = this.GetComponentInParent<MeleeWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyManager>().HPsum(-weapon.damage);
            other.GetComponent<Animator>().SetTrigger("hasBeenDamaged");
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
