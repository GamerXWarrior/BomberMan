using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectButton : MonoBehaviour
{
    public EventSystem eventSystem;
    public GameObject selectedObject;
    private bool selectedButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Vertical") !=0 && selectedButton == false)
        {
            eventSystem.SetSelectedGameObject(selectedObject);
            selectedButton = true;
        }
    }
    private void OnDisable()
    {
        selectedButton = false;
    }
}
