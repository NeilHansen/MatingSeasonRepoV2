using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour {
    const int GENE_SIZE = 4;
    [SerializeField] int[] heatAffinity = new int[GENE_SIZE];
    [SerializeField] int[] carnivority;
    [SerializeField] int[] litterSize;
    [SerializeField] int[] cancerSusceptibility;


    // Use this for initialization
    void Start () {
		
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
