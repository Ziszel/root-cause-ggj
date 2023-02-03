using System;
using UnityEngine;

public class ItemText : MonoBehaviour
{
    [SerializeField] private string initialText;
    [SerializeField] private string secondText;
    [SerializeField] private string thirdText;
    [SerializeField] private int textCount;

    private string _text;
    private int _count;
    private void Start()
    {
        _text = initialText;
        _count = 0;
    }

    private void UpdateText(int count)
    {
        switch (count)
        {
            case 0:
                _text = secondText;
                break;
            case 1:
                _text = thirdText;
                break;
            default:
                break;
        }
    }

    void OnTriggerStay2D(Collider2D collisionInfo)
    {
        if (collisionInfo.CompareTag("Player"))
        {
            if (Input.GetKeyDown("space"))
            {
                GameManager.Instance.PresentText(_text, this.transform);
                if (textCount > 0 && _count < textCount)
                {
                    UpdateText(_count);
                    _count++;
                }   
            }
        }
    }
}
