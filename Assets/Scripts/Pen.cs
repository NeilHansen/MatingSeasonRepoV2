using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pen : MonoBehaviour {

    //List<Animal> animals;
    List<GameObject> animals = new List<GameObject>();
    public string myName = "Empty";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter(Collider other)
    {
        //if (other.GetComponent<Animal>() != null && animals.Contains(other.GetComponent<Animal>()) == false)
        if(animals.Contains(other.gameObject) == false && other.gameObject.GetComponent<Animal>())
        {
            animals.Add(other.gameObject);

            if (myName == "Empty")
                myName = animals[0].GetComponent<Animal>().myName;
        }
            

        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Animal>())
        {
            animals.Remove(other.gameObject);

            if(animals.Count == 0)
            {
                myName = "Empty";
            }
        }
            
    }


    public List<GameObject> getAnimalList()
    {
        return animals;
    }
}
