using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheGloryHole : MonoBehaviour {

    private bool AnimalPresent = false;
    private bool StartMating = false;
    private int NumOfHits;
    public List<GameObject> parents;

    [SerializeField] public GameObject animalPrefab;


	// Use this for initialization
	void Start () {
        parents = new List<GameObject>();
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Animal")
        {
            AnimalPresent = true;
            StartMating = true;
            Debug.Log("MAting = " + StartMating);
            NumOfHits++;
            collision.gameObject.GetComponent<AnimalWander>().enabled = false;
            parents.Add(collision.gameObject);

            if(NumOfHits >= 2)
            {
                Debug.Log("sex ");
                NumOfHits = 0;
                Debug.Log(parents);
                GameObject animal = Instantiate(animalPrefab, transform.position, transform.rotation);
                this.gameObject.GetComponent<Mating>().mate(parents[0].GetComponent<Animal>(), parents[1].GetComponent<Animal>(), animal.GetComponent<Animal>());
              //  this.gameObject.GetComponent<Mating>().mate(parents[0], parents[1], Instantiate(animalPrefab, new Vector3(0,0,0), Quaternion.identity);
            }
          
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
