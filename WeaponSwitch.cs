using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour {

    public enum MainHandWeapons { Hand, Minigun }

    public GameObject weaponWheelL;

    public bool LweaponWheelEngaged;
    public bool RweaponWheelEngaged;

    public bool timescaleSlowed;
    public bool weaponSelected;

   // private bool cooldownStart;
    public float LcooldownTimer = 1f;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        
            WheelCooldown();
        

        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstick) && !LweaponWheelEngaged && LcooldownTimer == 0)
        {
            LcooldownTimer = 1f;
            weaponWheelL.SetActive(true);
            LweaponWheelEngaged = true;
           // cooldownStart = true;
            if (!timescaleSlowed)
            {
                SlowTimeScale();
            }
        }
    


        if(OVRInput.Get(OVRInput.Button.PrimaryThumbstick) && LweaponWheelEngaged && LcooldownTimer == 0)
        {
            LcooldownTimer = 1f;
            weaponWheelL.SetActive(false);
            LweaponWheelEngaged = false;
            if(timescaleSlowed && !RweaponWheelEngaged)
            {
                UnSlowTimeScale();
            }
        }
	}


    public void SlowTimeScale()
    {
        Time.timeScale = 0.1f;
       // Time.timeScale = Mathf.Lerp(1.0f, 0.1f, 1 * Time.deltaTime);
        timescaleSlowed = true;
    }

    public void UnSlowTimeScale()
    {
        Time.timeScale = 1f;
        //Time.timeScale = Mathf.Lerp(0.1f, 1f, 1 * Time.deltaTime);
        timescaleSlowed = false;
    }

    public void WheelCooldown()
    {
        if (timescaleSlowed) { LcooldownTimer -= Time.deltaTime * 10; }
        else { LcooldownTimer -= Time.deltaTime; }
        
        

        if(LcooldownTimer < 0)
        {
            LcooldownTimer = 0f;
        }

       
    }
}
