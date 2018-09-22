using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour {
    [SerializeField] GameObject head, body, neckHead, neckBody;


    [SerializeField] bool usePremadeGenes = false;

    [SerializeField] float headSizePerc;
    [SerializeField] float widthSizePerc;
    [SerializeField] float lengthPerc;

    [SerializeField] float heatAffinityPerc;
    [SerializeField] float carnivorityPerc;
    [SerializeField] float litterSizePerc;
    [SerializeField] float cancerSusceptibilityPerc;

    Color myColor;


    const int GENE_SIZE = 10;
    int[] heatAffinity = new int[GENE_SIZE];
    int[] carnivority;
    int[] litterSize;
    int[] cancerSusceptibility;

    int[] headSize;
    int[] width;
    int[] length;


    // Use this for initialization
    void Start () {
        // myColor = GetComponent<MeshRenderer>().material.color;    Now we have body parts?? This is getting intense...
        myColor = body.GetComponent<MeshRenderer>().material.color;
        
        


        if (usePremadeGenes)
        {
            heatAffinity = getGeneFromNum(getNumberofOnes(heatAffinityPerc));
            carnivority = getGeneFromNum(getNumberofOnes(carnivorityPerc));
            litterSize = getGeneFromNum(getNumberofOnes(litterSizePerc));
            cancerSusceptibility = getGeneFromNum(getNumberofOnes(cancerSusceptibilityPerc));

            headSize = getGeneFromNum(getNumberofOnes(headSizePerc));
            width = getGeneFromNum(getNumberofOnes(widthSizePerc));
            length = getGeneFromNum(getNumberofOnes(lengthPerc));
            // ADD MORE ONCE WE HAVE MORE TRAITS!!!!!!

            Debug.Log("heat gene generated from perc: " + printGene(heatAffinity));
            Debug.Log("carn gene generated from perc: " + printGene(carnivority));
            Debug.Log("litt gene generated from perc: " + printGene(litterSize));
            Debug.Log("canc gene generated from perc: " + printGene(cancerSusceptibility));
        }

        Vector3 headV = head.transform.localScale;
        headV.x = getPercFromGene(headSize) * 2 + 0.25f;    // * 2 because a chromose of "1100" (50%) should be normal, therefore *1.0f in scale.
        headV.y = getPercFromGene(headSize) * 2 + 0.25f;
        headV.z = getPercFromGene(headSize) * 2 + 0.25f;
        //head.transform.localScale = headV;

        neckHead.transform.localScale = headV;

        Vector3 bodyV = body.transform.localScale;
        bodyV.x = getPercFromGene(width) * 2 + 0.25f;
        bodyV.y = getPercFromGene(length) * 2 + 0.25f;
        bodyV.z = getPercFromGene(width) * 2 + 0.25f;
        //body.transform.localScale = bodyV;

        neckBody.transform.localScale = bodyV;


    

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

    float getPercFromGene(int[] myGene)
    {
        float perc = 0;
        for (int i = 0; i < GENE_SIZE; i++)
        {
            if (myGene[i] == 1)
            {
                perc += 1.0f / (float)GENE_SIZE;
            }
        }

        return perc;
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


    public void setGenes(int[] heat, int [] carn, int[] litt, int[] canc, int[] head, int[] wid, int[] leng)
    {
        heatAffinity = heat;
        carnivority = carn;
        litterSize = litt;
        cancerSusceptibility = canc;

        headSize = head;
        width = wid;
        length = leng;
    }

    public void mateWith(Animal otherParent, Animal child)
    {


        int[] heat = combineHalfGenes(getHalf(heatAffinity), getHalf(otherParent.heatAffinity));
        int[] carn = combineHalfGenes(getHalf(carnivority), getHalf(otherParent.carnivority));
        int[] litt = combineHalfGenes(getHalf(litterSize), getHalf(otherParent.litterSize));
        int[] canc = combineHalfGenes(getHalf(cancerSusceptibility), getHalf(otherParent.cancerSusceptibility));

        int[] head = combineHalfGenes(getHalf(headSize), getHalf(otherParent.headSize));
        int[] wid = combineHalfGenes(getHalf(width), getHalf(otherParent.width));
        int[] leng = combineHalfGenes(getHalf(length), getHalf(otherParent.length));
        // ADD MORE WHEN WE ADD MORE ATTRIBUTES


        child.setGenes(heat, carn, litt, canc, head, wid, leng);



        // NEW COLOR STUFF, MERGE PARENTS COLORS
        Color otherColor = otherParent.GetColor();
        Color temp = new Color();

        temp.a = (myColor.a + otherColor.a) / 2.0f;
        temp.r = (myColor.r + otherColor.r) / 2.0f;
        temp.g = (myColor.g + otherColor.g) / 2.0f;
        temp.b = (myColor.b + otherColor.b) / 2.0f;

        child.setColor(temp);

        // WHEN WE HAVE A "MERGING" ANIMATION, DELAY OR MODIFY THESE!!!
        Destroy(otherParent.gameObject);
        Destroy(this.gameObject);
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

        Debug.Log("temp : " + printGene(tempSeq));
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

    public Color GetColor()
    {
        return myColor;
    }

    public void setColor(Color newColor)
    {
        myColor = newColor;
        //GetComponent<MeshRenderer>().material.color = myColor;
        body.GetComponent<MeshRenderer>().material.color = myColor;
        head.GetComponent<MeshRenderer>().material.color = myColor;
    }
}
