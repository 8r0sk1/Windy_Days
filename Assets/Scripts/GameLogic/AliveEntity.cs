using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveEntity : MonoBehaviour
{
    public int max_hp;
    public int hp { protected set; get; }

    protected Rigidbody rBody;

    private void Start()
    {
        hp = max_hp;
    }

    virtual public void HPsum(int sum)
    {
        hp += sum;
    }
}
