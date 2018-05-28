using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class ItemPickup : MonoBehaviour {

    public enum ItemType { Ammo, PowerUp, Key };
    public enum AmmoType { None, Minigun, Grenade, Shotgun, Rocket, Laser };
    public enum PowerUpType { None, Health, Armor, QuadDamage, Haste, Barbarian };
    public enum KeyType {None, Red, Blue, Green, Yellow, Purple, Silver, Gold};

    public ItemType itemType;
    public AmmoType ammoType;
    public PowerUpType powerUpType;
    public KeyType keyType;

    public float Quantity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider c)
    {
       StartCoroutine(PickupDeath(c));
        //Destroy(this.gameObject, 0.2f);
    }


    public void PickupAmmo(Collider c)
    {
        if(c.tag == "Player")
        {
            //print(ammoType.ToString());
            c.GetComponent(ammoType.ToString()).SendMessage("AddAmmo", Quantity);


        }
        
    }

    public IEnumerator PickupDeath(Collider c)
    {
        PickupAmmo(c);
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}







