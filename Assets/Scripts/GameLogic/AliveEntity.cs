using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveEntity : MonoBehaviour
{
    public int max_hp { private set; get; }
    public int hp;

    protected Rigidbody rBody;

    public void HPsum(int sum)
    {
        hp += sum;
    }

    // Start is called before the first frame update
    void Start()
    {
        hp = max_hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
