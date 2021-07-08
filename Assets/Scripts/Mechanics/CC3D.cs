using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLib;

namespace GameLib
{
    public enum attack_type { slash1, slash2, special};
}
public class CC3D : MonoBehaviour
{
    private PlayerManager playerManager;
    private Rigidbody rBody;

    public float movementSpeed = 5f, dashSpeed = 7.5f, rotationSpeed = 0.125f;
    private float InputX, InputZ;
    private bool isDashing = false;
    private bool isAttacking = false;
    private bool isCloud = false;
    private bool isParrying = false;
    private Vector2 speedVector;
    private Animator anim;
    public float dashTime;
    public float maxCloudTime;
    private bool isBottling;
    private bool bottlingEnabled;
    public MeleeWeapon weapon, shield;
    private attack_type attack;
    //public GameObject bodyMesh, cloudMesh;
    private float elapsedCloudTime;
    public bool isRollDisabled;

 

    void Start()
    {
        playerManager = this.GetComponent<PlayerManager>();
        rBody = this.GetComponent<Rigidbody>();
        anim = this.GetComponentInChildren<Animator>();

        rBody.useGravity = true;
        bottlingEnabled = true;
    }

    void Update()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");
        speedVector = new Vector2(InputX, InputZ);
        if (speedVector.magnitude > 0.1)
            anim.SetBool("isRunning_TD", true);
        else
            anim.SetBool("isRunning_TD", false);
        anim.SetFloat("runSpeed", Mathf.Max(Mathf.Abs(speedVector.x), Mathf.Abs(speedVector.y)));
        anim.SetFloat("dashSpeed", dashSpeed);

        if (Input.GetButtonDown("Jump") && !isDashing && !isCloud && !isParrying && !isRollDisabled)
        {
            //dashElapsedTime = 0f;
            //toDash = true;

            isDashing = true;
            anim.SetTrigger("toDash");
        }

        if (Input.GetButtonDown("Fire1") )
        {
            attack = attack_type.slash1;
            anim.SetTrigger("attack1");
            isAttacking = true;

        
            

        }

        if (Input.GetButtonDown("Fire2"))
        {
            attack = attack_type.slash2;
            anim.SetTrigger("attack2");
            isAttacking = true;
        }
        if (Input.GetButtonDown("Crouch") && playerManager.objFlags[(int)playerObj.bottle])
        {
            if (bottlingEnabled)
            {
                isBottling = true;
                bottlingEnabled = false;
            }
        }

        //DEBUG
        Debug.Log("Axis Input: " + Input.GetAxis("Shield"));

        if ((Input.GetButtonDown("Shield") || (Input.GetAxis("Shield") > 0.1f)) && !isCloud && playerManager.objFlags[(int)playerObj.shield])
        {
            if (!isParrying) anim.SetTrigger("parry");
            else anim.ResetTrigger("parry");  
        }

        if (Input.GetButtonDown("Cloud") && !isParrying && playerManager.objFlags[(int)playerObj.necklace])
        {
            isCloud = true;
            elapsedCloudTime = 0;
            playerManager.bodyMesh.SetActive(false);
            this.GetComponent<CapsuleCollider>().enabled = false;
            this.GetComponent<Rigidbody>().useGravity = false;
            playerManager.cloud.SetActive(true);
            playerManager.cloud.GetComponentInChildren<MeleeWeapon>().EnableHitbox(attack_type.special);
        }

        if (isCloud)
        {
            if (elapsedCloudTime > maxCloudTime)
            {
                isCloud = false;
                playerManager.bodyMesh.SetActive(true);
                this.GetComponent<CapsuleCollider>().enabled = true;
                this.GetComponent<Rigidbody>().useGravity = true;
                playerManager.cloud.SetActive(false);
                playerManager.cloud.GetComponentInChildren<MeleeWeapon>().DisableHitbox();
            }
            else
                elapsedCloudTime += Time.deltaTime;
        }

        if (isDashing)
        {
            if (weapon.hitBox.active) DisableWeaponHitbox(); //???
        }
    }

    private void FixedUpdate()
    {
        Vector3 move;
        if (!isDashing && !isAttacking)
            move = new Vector3(InputX, 0f, InputZ);
        else
            move = Vector3.zero;

        if (isBottling)
        {
            //Debug.Log("Woooosh");
            RaycastHit hit;
            if(Physics.Raycast(this.transform.position, this.transform.forward*5, out hit, 20000 ))
            {
                Debug.DrawRay(this.transform.position, this.transform.forward*5, Color.red, 5f);
                if (hit.transform.gameObject.CompareTag("Movable_sand")) 
                {
                    Debug.Log("SAND");
                    //Play disappearing sand animation from sand mass animator 
                    MeshRenderer m = hit.transform.gameObject.GetComponent<MeshRenderer>();
                    BoxCollider b = hit.transform.gameObject.GetComponent<BoxCollider>();
                    m.enabled = false;
                    b.enabled = false;
                }

            }
            isBottling = false;
            bottlingEnabled = true;
        }

        //rotazione
        if (Mathf.Clamp(move.magnitude,0,1) > 0f && !isDashing)
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(move.normalized),rotationSpeed);
        
        //controllo move
        if(!isDashing && !isAttacking && !isParrying)
        {
            float speedFactor = Mathf.Clamp(Mathf.Abs(move.x) + Mathf.Abs(move.z), 0f, 1f);
            rBody.MovePosition(this.transform.position + move.normalized * speedFactor * movementSpeed * Time.deltaTime);
        }

        //DEBUG
        //Debug.Log(rBody.velocity);
    }

    public void EnableWeaponHitbox()
    {
        weapon.EnableHitbox(attack);
    }

    public void DisableWeaponHitbox()
    {
        weapon.DisableHitbox();
    }

    public void EnableShieldHitbox()
    {
        shield.EnableHitbox(attack);
    }

    public void DisableShieldHitbox()
    {
        shield.DisableHitbox();
    }

    public void AnimSpeedChange(float arg)
    {
        anim.SetFloat("animSpeed", arg);
    }

    public void DashEvent(int arg)
    {
        isDashing = (arg == 0) ? false : true;

        //DEBUG
        Debug.Log(isDashing);
    }

    public void AttackEvent(int arg)
    {
        isAttacking = (arg == 0) ? false : true;

        //DEBUG
        Debug.Log(isAttacking);
    }

    public void ParryEvent(int arg) { 
        isParrying = (arg == 0) ? false : true;
    }
}
