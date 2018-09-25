using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalShop : MonoBehaviour {


    [SerializeField] public  GameObject animalPen;
	public void BuyAnimal(GameObject animalPrefab)
    {
        GameObject animal = Instantiate(animalPrefab, animalPen.transform.position, animalPen.transform.rotation);
        GameObject animal1 = Instantiate(animalPrefab, animalPen.transform.position - new Vector3 (0,0,5.0f) , transform.rotation);
        Debug.Log(animal.transform.position);

    }
}
