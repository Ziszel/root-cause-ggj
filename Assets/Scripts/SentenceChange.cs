using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SentenceChange : MonoBehaviour
{
    public List<string> ScentenceList = new List<string>();
    public int listIndex;
    public TMP_Text text;
    public GameObject scentencePanel;
    public List<Sprite> sprites = new List<Sprite>();
    public Image image;
    public int SceneID;
    public int max;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(listIndex<max)
        {
            flip();
        }
    }

    void flip()
    {
        if(Input.GetMouseButtonDown(0))
        {
            text.text = ScentenceList[listIndex].ToString();
            listIndex++;
        }
    }

    void imageChange()
    {
        if(SceneID==1)
        {

        }
    }

    void PanelAppear()
    {
        scentencePanel.SetActive(true);
    }

    void PanelDisappear()
    {
        scentencePanel.SetActive(false);
    }
}
