using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour {
    [SerializeField] bool usePremadeGenes = false;

    [SerializeField] float heatAffinityPerc;
    [SerializeField] float carnivorityPerc;
    [SerializeField] float litterSizePerc;
    [SerializeField] float cancerSusceptibilityPerc;




    const int GENE_SIZE = 4;
    int[] heatAffinity = new int[GENE_SIZE];
    int[] carnivority;
    int[] litterSize;
    int[] cancerSusceptibility;


    // Use this for initialization
    void Start () {

        if (usePremadeGenes)
        {
            heatAffinity = getGeneFromNum(getNumberofOnes(heatAffinityPerc));
            carnivority = getGeneFromNum(getNumberofOnes(carnivorityPerc));
            litterSize = getGeneFromNum(getNumberofOnes(litterSizePerc));
            cancerSusceptibility = getGeneFromNum(getNumberofOnes(cancerSusceptibilityPerc));
            // ADD MORE ONCE WE HAVE MORE TRAITS!!!!!!

            Debug.Log("heat gene generated from perc: " + printGene(heatAffinity));
            Debug.Log("carn gene generated from perc: " + printGene(carnivority));
            Debug.Log("litt gene generated from perc: " + printGene(litterSize));
            Debug.Log("canc gene generated from perc: " + printGene(cancerSusceptibility));
        }

	}

    string printGene(int[] gene)
    {
        string temp = "";

        for (int i = 0; i < GENE_SIZE; i++)
        {
            temp += gene[i];
        }
        return temp;
    }

    int[] getGeneFromNum(int num)
    {
        int[] temp = new int[GENE_SIZE];

        for (int i = 0; i < GENE_SIZE; i++)
        {
            if (i < num)
            {
                temp[i] = 1;
            }
            else
            {
                temp[i] = 0;
            }
        }

        return temp;
    }

    int getNumberofOnes(float percWanted)
    {
        float difference = 2.0f;
        int numberOfOnes = 0;

        for (int i = 0; i < GENE_SIZE; i++)
        {
            float temp = Mathf.Abs(((float)i / (float)GENE_SIZE) - percWanted);

            if (temp < difference)
            {
                difference = temp;
                numberOfOnes = i;
            }
                
        }

        return numberOfOnes;
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void setGenes(int[] heat, int [] carn, int[] litt, int[] canc)
    {
        heatAffinity = heat;
        carnivority = carn;
        litterSize = litt;
        cancerSusceptibility = canc;
    }

    public void mateWith(Animal otherParent, Animal child)
    {


        int[] heat = combineHalfGenes(getHalf(heatAffinity), getHalf(otherParent.heatAffinity));
        int[] carn = combineHalfGenes(getHalf(carnivority), getHalf(otherParent.carnivority));
        int[] litt = combineHalfGenes(getHalf(litterSize), getHalf(otherParent.litterSize));
        int[] canc = combineHalfGenes(getHalf(cancerSusceptibility), getHalf(otherParent.cancerSusceptibility));
        // ADD MORE WHEN WE ADD MORE ATTRIBUTES


        child.setGenes(heat, carn, litt, canc);
    }

    int[] combineHalfGenes(int[] a1, int[] a2)
    {

        int[] temp = new int[GENE_SIZE];
        for (int i = 0; i < GENE_SIZE / 2; i++)
        {
            temp[i] = a1[i];
        }
        for (int i = 0; i < GENE_SIZE / 2; i++)
        {
            temp[i + (GENE_SIZE / 2)] = a2[i];
        }

        return temp;
    }

    int[] getHalf(int[] gene)
    {
        int[] tempSeq = gene;

        // RANDOMIZE FIRST
        for (int i = 0; i < GENE_SIZE; i++)
        {
            int temp = tempSeq[0];
            int other = Random.Range(1, GENE_SIZE);
            tempSeq[0] = tempSeq[other];
            tempSeq[other] = temp;
        }

        //THEN SEND THE FIRST HALF
        int[] halfGene = new int[GENE_SIZE / 2];

        for (int i = 0; i < GENE_SIZE/2; i++)
        {
            halfGene[i] = tempSeq[i];
        }
        return halfGene;
    }
}
