﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeManager : MonoBehaviour {

    [SerializeField] Animal animalToCompare;

    [SerializeField] Image Icon1, Icon2, Icon3;
    [SerializeField] Text req1, req2, req3;
    Image[] images;
    Text[] texts;
    

    int numberOfCriteria = 3;   // IF YOU CHANGE THIS< MODIFY COMPARE FUNCTION
    const int numberOfTraits = 4;

    Recipe demand;




	// Use this for initialization
	void Start () {

        images = new Image[] { Icon1, Icon2, Icon3};
        texts = new Text[] { req1, req2, req3 };

        demand = getRandomRecipe();
        updateDemandUI();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void updateDemandUI()
    {
        int counter = 0;

        if (demand.expectedCanc > -0.5)
        {
            texts[counter].text = percToText(demand.expectedCanc);
            counter++;
        }
        if (demand.expectedCarn > -0.5)
        {
            texts[counter].text = percToText(demand.expectedCarn);
            counter++;
        }
        if (demand.expectedHeat > -0.5)
        {
            texts[counter].text = percToText(demand.expectedHeat);
            counter++;
        }
        if (demand.expectedLitt > -0.5)
        {
            texts[counter].text = percToText(demand.expectedLitt);
            counter++;
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

    public Recipe getRandomRecipe()
    {
        int counter = 0;
        Recipe rec = new Recipe();

        while (counter < numberOfCriteria)
        {
            int rand = Random.Range(0, numberOfTraits);
            int traitPercWanted = Random.Range(0, 6);

            switch (rand)
            {
                case 0:
                    if (rec.expectedCanc < 0)   // -1 means not part of recipe, yet
                    {
                        counter++;
                        rec.expectedCanc = ((float)traitPercWanted * 20)/100.0f;
                    }
                    break;
                case 1:
                    if (rec.expectedCarn < 0)   // -1 means not part of recipe, yet
                    {
                        counter++;
                        rec.expectedCarn = ((float)traitPercWanted * 20)/100.0f;
                    }
                    break;
                case 2:
                    if (rec.expectedHeat < 0)   // -1 means not part of recipe, yet
                    {
                        counter++;
                        rec.expectedHeat = ((float)traitPercWanted * 20)/100.0f;
                    }
                    break;
                case 3:
                    if (rec.expectedLitt < 0)   // -1 means not part of recipe, yet
                    {
                        counter++;
                        rec.expectedLitt = ((float)traitPercWanted * 20)/100.0f;
                    }
                    break;
                default:
                    Debug.Log("ERROR IN RANDOM RECIPE GEN");
                    break;
            }


        }
        return rec;


    }


    public float compareAnimal(Recipe rec)
    {
        float successPerc = 0.0f;

        if (rec.expectedCanc > -0.5)
        {
            float temp = animalToCompare.getPercFromGene(animalToCompare.cancerSusceptibility) - rec.expectedCanc;
            successPerc += 1 - temp;
        }
        if (rec.expectedCarn > -0.5)
        {
            float temp = animalToCompare.getPercFromGene(animalToCompare.carnivority) - rec.expectedCarn;
            successPerc += 1 - temp;
        }
        if (rec.expectedHeat > -0.5)
        {
            float temp = animalToCompare.getPercFromGene(animalToCompare.heatAffinity) - rec.expectedHeat;
            successPerc += 1 - temp;
        }
        if (rec.expectedLitt > -0.5)
        {
            float temp = animalToCompare.getPercFromGene(animalToCompare.litterSize) - rec.expectedLitt;
            successPerc += 1 - temp;
        }

        successPerc = successPerc / numberOfCriteria;

        return successPerc;

    }


    public class Recipe
    {
        public float expectedHeat = -1
            , expectedCarn = -1, expectedLitt = -1, expectedCanc = -1;
    }

}
