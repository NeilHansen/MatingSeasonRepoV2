using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour {


    [SerializeField] GameObject goldSlider;
    [SerializeField] Text goldText;
	
	// Update is called once per frame
	void Update () {
       goldText.text = "GOLD:" + goldSlider.GetComponent<Slider>().value;
	}
}
