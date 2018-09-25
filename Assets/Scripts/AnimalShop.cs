using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalShop : MonoBehaviour {

    float money;
    [SerializeField] Slider goalSlider;
    [SerializeField] int price = 150;


    [SerializeField] public  GameObject animalPen;

    public void BuyAnimal(GameObject animalPrefab)
    {
        money = goalSlider.value;

        if (money >= price)
        {
            GameObject animal = Instantiate(animalPrefab, animalPen.transform.position, animalPen.transform.rotation);
            GameObject animal1 = Instantiate(animalPrefab, animalPen.transform.position - new Vector3(0, 0, 5.0f), transform.rotation);
            Debug.Log(animal.transform.position);

            money -= price;
            goalSlider.value = money;

        }


    }
}
