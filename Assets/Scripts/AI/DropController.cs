using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour
{

    public List<WeightedDrop> dropTable;

    //TODO: Make drop code
    //TODO: Property Drawers

	// Use this for initialization
    
    public void Drop()
    {
        //Drop object
        Instantiate(GetRandomItem(), transform.position + Vector3.up, transform.rotation);
    }


    public GameObject GetRandomItem()
    {
        List<float> CDFArray = new List<float>();

        int index = 0;
        float total = 0;
        foreach (WeightedDrop drop in dropTable)
        {
            total += dropTable[index].weight;
            CDFArray.Add(total);
            index++;
        }

        float randomNumber = Random.Range(0.0f, total);

        int selectedIndex = System.Array.BinarySearch(CDFArray.ToArray(), randomNumber);
        if (selectedIndex < 0)
        {
            selectedIndex = ~selectedIndex;
        }
        return dropTable[selectedIndex].objectToDrop;

        //Does the same thing
        /*-----
        for (int i = 0; i < CDFArray.Count; i++)
        {
            if (randomNumber < CDFArray[i])
            {
                return dropTable[i].objectToDrop;
            }
        }
        return dropTable[dropTable.Count - 1].objectToDrop;
        -----*/
    }
}
