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
            other.gameObject.GetComponent<EnemyManager>().HPsum(-weapon.damage);
            //DEBUG
            Debug.Log("Hitted " + other);
        }
    }
}
