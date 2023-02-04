using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseKiller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void End(int endNumber)
    {
        if (endNumber == 0)
        {
            //change to the HappyEnding
            SceneManager.LoadScene("HappyEnding");
        }
        else if (endNumber == 1)
        {
            //change to the SadEnding
            SceneManager.LoadScene("SadEnding");
        }
    }
}
