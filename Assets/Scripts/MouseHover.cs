using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseHover : MonoBehaviour {

    [SerializeField] GameObject AnimalInfoPanel;
    [SerializeField] Text AnimalNameText;
    [SerializeField] string PenType;

    [SerializeField] Text text1, text2, text3, text4;


    Pen currentPen;

    private void Start()
    {
        AnimalInfoPanel.SetActive(false);
    }

    void OnMouseOver()
    {
        
        //AnimalNameText.text = "" + PenType;
        
        List<GameObject> list = GetComponent<Pen>().getAnimalList();

        if(list.Count > 0)
        {
            AnimalInfoPanel.SetActive(true);
            AnimalNameText.text = GetComponent<Pen>().myName;


            text1.text = percToText(list[0].GetComponent<Animal>().getPercFromGene(list[0].GetComponent<Animal>().heatAffinity));
            text2.text = percToText(list[0].GetComponent<Animal>().getPercFromGene(list[0].GetComponent<Animal>().carnivority));
            text3.text = percToText(list[0].GetComponent<Animal>().getPercFromGene(list[0].GetComponent<Animal>().litterSize));
            text4.text = percToText(list[0].GetComponent<Animal>().getPercFromGene(list[0].GetComponent<Animal>().cancerSusceptibility));
        }

        Debug.Log("Mouse over " + this.gameObject.name);
    }

    void OnMouseExit()
    {
        AnimalInfoPanel.SetActive(false);
        Debug.Log("Mouse left " + this.gameObject.name);
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
