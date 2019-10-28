using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BowController : MonoBehaviour
{
    public Transform weaponHold;
    public Bow startingBow;
    Bow equipedBow;

    void Start()
    {
        startingBow = gameObject.GetComponent("bow") as Bow;
        //if (startingBow != null)
        //{
        //    EquipBow(startingBow);
        //}
    }

    public void EquipBow(Bow bowtoEquip)
    {
        if (equipedBow != null)
        {
            Destroy(equipedBow.gameObject);
        }
        equipedBow = Instantiate(bowtoEquip, weaponHold.position, weaponHold.rotation) as Bow;
        equipedBow.transform.parent = weaponHold;
    }
}
