using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class RobotJetpack : MonoBehaviour {

    public AudioSource Thruster;
    public AudioClip Thrustersound;
    private bool IsPlaying = true;

    public float Speed = 3;

    public CharacterController Robot;
    public FirstPersonController FPC;

    public Vector3 currentVector = Vector3.up;

    public float currentForce = 0;

    public float MaxForce = 5;

	// Use this for initialization
	void Update ()
    {
		if (Input.GetKey(KeyCode.Space))
        {
            
            if (IsPlaying == false)
            {
                Thruster.PlayOneShot(Thrustersound, 0.5f);
                IsPlaying = true;
                
            }
            
        }
        else
        {
            IsPlaying = false;
            Thruster.Stop();
        }
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        // reduce max force over time
        if (Input.GetKey(KeyCode.Space) && MaxForce > 0)
        {
            MaxForce -= Time.deltaTime;

            if (currentForce < 1)
            {
                currentForce += Time.deltaTime * 10;
            }
            else
            {
                currentForce = 1;
            }
        }

        if (MaxForce < 0 && currentForce > 0)
        {
            // start falling if no force left
            currentForce -= Time.deltaTime;
        }

        if (!Input.GetKey(KeyCode.Space))
        {
            

            if (currentForce > 0)
            {
                currentForce -= Time.deltaTime;
            }
            else
            {
                currentForce = 0;
            }

            if (MaxForce < 5)
            {
                MaxForce += Time.deltaTime;
            }
            else
            {
                MaxForce = 5;
            }
        }

        if (currentForce > 0)
        {
            UseJetPack();
        }
	}

    public void UseJetPack()
    {
        // fly using jetpack
        if(FPC.m_Jump)
        {
            FPC.m_Jump = false;
        }
        currentVector = Vector3.up;

        currentVector += transform.right * Input.GetAxis("Horizontal");
        currentVector += transform.forward * Input.GetAxis("Vertical");

        Robot.Move((currentVector * Speed * Time.fixedDeltaTime - Robot.velocity * Time.fixedDeltaTime) * currentForce);
    }
}
