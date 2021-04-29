using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddForceDemonstration : MonoBehaviour
{

    private Rigidbody rBody;
    public Vector3 vector;
    public ForceMode mode;
    public bool triggered;
    public bool triggerPull;

    // Start is called before the first frame update
    void Start()
    {
        rBody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Jump"))
        {
            triggerPull = true;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void FixedUpdate()
    {
        if (triggered) {
            if (triggerPull)
            {
                rBody.AddForce(vector, mode);
                triggerPull = false;
            }
        }
        else
            rBody.AddForce(vector, mode);

    }
}
