using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBook : MonoBehaviour
{
    public GameObject Book;
    public GameObject PersonInformation;
    public GameObject Close;
    // Start is called before the first frame update
    void Start()
    {
        Book.SetActive(false);
        PersonInformation.SetActive(false);
        Close.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        Book.SetActive(true);
        PersonInformation.SetActive(true);
        Close.SetActive(true);
    }
}
