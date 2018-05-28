using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigun : MonoBehaviour {

    public bool isEquipped;
    public int Ammo;
    public float damage;


    public GameObject minigunAmmoText;

    public float rotationTimeInterval = 0.1f;
    public float rotationTime;
    public float rotationSpeed;
    //public float spinDownTime;
    public float rateOfFireTimeInterval = 0.08f;
    public float rateOfFireTimer;

    //
    public AudioSource gunSounds;
    public bool isFiring;
    public GameObject minigunBarrel;
    public Light muzzleflashLight;
    public Transform bulletOrigin;

    private RaycastHit primaryFireRaycastHit;
	// Use this for initialization
	void Start () {
        minigunAmmoText.GetComponent<Text>().text = Ammo.ToString();
	}
	
	// Update is called once per frame
	void Update () {

        audioSetup();

        minigunBarrel.transform.Rotate(new Vector3(0, 0, rotationSpeed  * Time.deltaTime));

        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.2f)
        {
            SpinUp();
            PrimaryFire();
         

        }
        else
        {
            isFiring = false;
            muzzleflashLight.enabled = false;
            gunSounds.Pause();
            SpinDown();
            //rotationTime = 0;
        }
	}


    void SpinUp()
    {
        rotationTime += Time.deltaTime;

        if (rotationSpeed <= 1400)
        {
            if (rotationTime > rotationTimeInterval)
            {
                rotationTime = 0;
                rotationSpeed+=100;
            }
        }
    }


    void SpinDown()
    {
        rotationTime += Time.deltaTime;

        if(rotationSpeed > 0)
        {
            if (rotationTime > rotationTimeInterval)
            {
                rotationTime = 0;
                rotationSpeed -= 100;
            }
        }
    }

    void PrimaryFire()
    {
        if (rotationSpeed >= 1400)
        {
            rateOfFireTimer += Time.deltaTime;

            if(rateOfFireTimer > rateOfFireTimeInterval)
            {
                rateOfFireTimer = 0;
             if(Ammo > 0)
                {
                    minigunAmmoText.GetComponent<Text>().text = Ammo.ToString();
                    Ammo--;
                    muzzleflashLight.intensity = Random.Range(0.95f, 1.15f);
                    if (!isFiring)
                    {
                        isFiring = true;
                        gunSounds.Play();
                        muzzleflashLight.enabled = true;
                    }
                    //print("its working asshole");
                    if (Physics.Raycast(bulletOrigin.transform.position, bulletOrigin.transform.forward, out primaryFireRaycastHit))
                    {
                        Debug.DrawLine(bulletOrigin.transform.position, primaryFireRaycastHit.point, Color.red, 4.0f);
                        DoDamage(primaryFireRaycastHit.collider);
                    }
                }
                else
                {
                    //click click click
                }      
            }         
        }
        else
        {
            rateOfFireTimer = 0;
        }
    }


    public void AddAmmo(int f)
    {
        Ammo += f;
        minigunAmmoText.GetComponent<Text>().text = Ammo.ToString();
        print("ammo added");
    }


    public void DoDamage(Collider c)
    {
        if (c.gameObject.tag == "Enemy")
        {
            DamageScript ds = c.gameObject.GetComponent<DamageScript>();

            ds.AddDamage(damage);
        }
    }

    public void audioSetup()
    {
        gunSounds.pitch = Time.timeScale;
    }

}
