using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatingMouseHover : MonoBehaviour {

    [SerializeField] GameObject AnimalInfoPanel;
    [SerializeField] Text AnimalNameText;
    [SerializeField] Text text1, text2, text3, text4;


    List<GameObject> animals = new List<GameObject>();


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseOver()
    {
        if (GetComponent<TheGloryHole>().parents.Count == 1)
        {
            //List<GameObject> temp = new List<GameObject>();
            animals = GetComponent<TheGloryHole>().parents;

            AnimalInfoPanel.SetActive(true);
            text1.text = percToText(animals[0].GetComponent<Animal>().getPercFromGene(animals[0].GetComponent<Animal>().heatAffinity));
            text2.text = percToText(animals[0].GetComponent<Animal>().getPercFromGene(animals[0].GetComponent<Animal>().carnivority));
            text3.text = percToText(animals[0].GetComponent<Animal>().getPercFromGene(animals[0].GetComponent<Animal>().litterSize));
            text4.text = percToText(animals[0].GetComponent<Animal>().getPercFromGene(animals[0].GetComponent<Animal>().cancerSusceptibility));
        }
    }

    void OnMouseExit()
    {
        AnimalInfoPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.GetComponent<Animal>() != null && animals.Contains(other.GetComponent<Animal>()) == false)
        if (animals.Contains(other.gameObject) == false && other.gameObject.GetComponent<Animal>())
        {
            animals.Add(other.gameObject);

        }

    }

    public void refreshAnimalList()
    {
        animals = new List<GameObject>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Animal>())
        {
            animals.Remove(other.gameObject);

        }
    }


    string percToText(float perc)
    {
        if (perc < .15f)
        {
            return "Minimu";
        }
        else if (perc < .35f)
        {
            return "Low";
        }
        else if (perc < .65f)
        {
            return "Medium";
        }
        else if (perc < .85f)
        {
            return "High";
        }
        else if (perc <= 1.0f)
        {
            return "Maximum";
        }
        else
        {
            return "ERROR";
        }
    }

}
