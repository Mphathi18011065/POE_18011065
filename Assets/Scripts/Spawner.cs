using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] theUnits;
    public int Xpos;
    public int Zpos;
    private int unitCount;
    public int amount;

    void Start()
    {
        StartCoroutine(UnitDrop());
    }

    IEnumerator UnitDrop()
    {
        for (int i = 0; i < 2; i++)
        {
            while (unitCount < amount)
            {
                Xpos = Random.Range(10, 118);
                Zpos = Random.Range(14, 100);
                Instantiate(theUnits[Random.Range(0, theUnits.Length)], new Vector3(Xpos, -109, Zpos), transform.rotation);
                yield return new WaitForSeconds(0.1f);
                unitCount += 1;

            }
        }

    }
}
