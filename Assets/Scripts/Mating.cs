using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mating : MonoBehaviour {

    [SerializeField] Animal defaultParent1, defaultParent2;
    [SerializeField] Animal child;



	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void mate()
    {
        defaultParent1.mateWith(defaultParent2, child);
    }

    public void mate(Animal parent1, Animal parent2, Animal child)
    {
        defaultParent1 = parent1;
        defaultParent2 = parent2;
        this.child = child;
        mate();
    }
   
}
