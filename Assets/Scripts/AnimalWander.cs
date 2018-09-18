using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalWander : MonoBehaviour {

    public float MoveSpeed = 3.0f;
    public float RotSpeed = 100.0f;

    private bool IsWandering = false;
    private bool IsMovingRight = false;
    private bool IsMovingLeft = false;
    private bool IsMoving = false;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!IsWandering)
        {
            StartCoroutine(WanderRoutine());
        }

        if(IsMovingRight)
        {
            transform.position -= transform.right * Time.deltaTime * -RotSpeed;// move right rather then turn
           // transform.Rotate(transform.up * Time.deltaTime * RotSpeed);
            Debug.Log("rotating");
        }
        if(IsMovingLeft)
        {
            transform.position += transform.right * Time.deltaTime * -RotSpeed;// move left rather then turn.
            //transform.Rotate(transform.up * Time.deltaTime * -RotSpeed);
            Debug.Log("rotating");
        }
        if(IsMoving)
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            
            Debug.Log("moving");
        }
	}


   IEnumerator WanderRoutine()
    {
        int rotTime = Random.Range(1, 2);
        int rotWait = Random.Range(1, 3);
        int rotLorR = Random.Range(1, 2);
        int moveTime = Random.Range(1, 5);
        int moveWait = Random.Range(1, 3);

        IsWandering = true;
        
        yield return new WaitForSeconds(moveWait);
        IsMoving = true;
        yield return new WaitForSeconds(moveTime);
        IsMoving = false;
        yield return new WaitForSeconds(rotWait);
        if(rotLorR == 1)
        {
            IsMovingRight = true;
            yield return new WaitForSeconds(rotTime);
            IsMovingRight = false;
        }
        if(rotLorR == 2)
        {
            IsMovingLeft = true;
            yield return new WaitForSeconds(rotTime);
            IsMovingLeft = false;
        }
        IsWandering = false;
    }
}
