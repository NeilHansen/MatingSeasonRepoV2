using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseHover : MonoBehaviour {

    [SerializeField] GameObject AnimalInfoPanel;
    [SerializeField] Text AnimalNameText;
    [SerializeField] string PenType;

    void OnMouseOver()
    {
        AnimalInfoPanel.SetActive(true);
        AnimalNameText.text = "" + PenType;
        Debug.Log("Mouse over " + this.gameObject.name);
    }

    void OnMouseExit()
    {
        AnimalInfoPanel.SetActive(false);
        Debug.Log("Mouse left " + this.gameObject.name);
    }

}
