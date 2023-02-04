using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    //1209
    public Button btn1;
    //1026
    public Button btn2;
    //meeting room
    public Button btn3;
    // Start is called before the first frame update
    void Start()
    {
        if(!GameManager.Instance.door(1))
        {
            btn2.interactable = false;
        }
        if(!GameManager.Instance.door(2))
        {
            btn3.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeRoom(int doorNumber)
    {
        switch(doorNumber)
        {
            case 0:
                //SceneManager.LoadScene("");
                btn2.interactable = true;
                GameManager.Instance.canOpenDoorArray[1] = true;
                break;
            case 1:
                //SceneManager.LoadScene("");
                btn3.interactable = true;
                GameManager.Instance.canOpenDoorArray[2] = true;
                break;
            case 2:
                //SceneManager.LoadScene("");
                break;
            default:
                break;
        }
    }
}
