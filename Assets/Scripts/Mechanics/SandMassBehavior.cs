using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandMassBehavior : MonoBehaviour
{
    private MeshRenderer m;
    private BoxCollider b;
    private ParticleSystem p;
    private GameObject Player;
    private bool blown;
    // Start is called before the first frame update

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Sand HIT");
            Animator robot_animator = other.gameObject.GetComponent<Animator>();
            robot_animator.SetBool("isStunned", true);
    }
    void Start()
    {
        m = this.GetComponent<MeshRenderer>();
        b = this.GetComponent<BoxCollider>();
        p = this.GetComponent<ParticleSystem>();
        p.Stop();
        Player = GameObject.FindGameObjectWithTag("Player");
        blown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (m.enabled == false && b.enabled == false && blown == false)
        {
            blown = true;
            p.transform.rotation = Player.transform.rotation;
            p.Play();
            
        }
    }
}
    
