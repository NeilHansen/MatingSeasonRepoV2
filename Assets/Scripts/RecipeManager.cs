using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour {

    [SerializeField] Animal animalToCompare;

    

    int numberOfCriteria = 3;   // IF YOU CHANGE THIS< MODIFY COMPARE FUNCTION
    const int numberOfTraits = 4;






	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Recipe getRandomRecipe()
    {
        int counter = 0;
        Recipe rec = new Recipe();

        while (counter < numberOfCriteria)
        {
            int rand = Random.Range(0, numberOfTraits);
            int traitPercWanted = Random.Range(0, 5);

            switch (rand)
            {
                case 0:
                    if (rec.expectedCanc < 0)   // -1 means not part of recipe, yet
                    {
                        counter++;
                        rec.expectedCanc = traitPercWanted * 20;
                    }
                    break;
                case 1:
                    if (rec.expectedCarn < 0)   // -1 means not part of recipe, yet
                    {
                        counter++;
                        rec.expectedCarn = traitPercWanted * 20;
                    }
                    break;
                case 2:
                    if (rec.expectedHeat < 0)   // -1 means not part of recipe, yet
                    {
                        counter++;
                        rec.expectedHeat = traitPercWanted * 20;
                    }
                    break;
                case 3:
                    if (rec.expectedLitt < 0)   // -1 means not part of recipe, yet
                    {
                        counter++;
                        rec.expectedLitt = traitPercWanted * 20;
                    }
                    break;
                default:
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
