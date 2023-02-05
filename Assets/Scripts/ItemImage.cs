using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemImage : ItemText
{
    //Select a Texture in the Inspector to change to
    public RawImage image;
    public RawImage screenOverlay;
    public Texture screenOverlayTexture;
    public TMP_Text textbox;
    private int _textCount;
    private int _currentTextCount;
    private List<string> _textList;

    public void Start()
    {
        _currentTextCount = 0;
        _textList = GenerateTextList();
        textbox.text = "";
    }

    public List<string> GenerateTextList()
    {
        List<string> returnValue = new List<string>();
        if (initialText != null)
        {
            returnValue.Add(initialText);
            _textCount = 0;
        }
        
        if (secondText != "")
        {
            returnValue.Add(secondText);
            _textCount = 1;
        }

        if (thirdText != "")
        {
            returnValue.Add(thirdText);
            _textCount = 2;
        }
        return returnValue;
    }

    private void SetText(int textRef)
    {
        textbox.text = GenerateTextList()[textRef];
    }

    public void HandleUI()
    {
        if (GameManager.Instance.imageOverlayOn && _currentTextCount == _textCount + 1)
        {
            ReturnUI();
            _currentTextCount = 0;
        }
        else
        {
            SetText(_currentTextCount);
            screenOverlay.texture = image.texture;
            GameManager.Instance.imageOverlayOn = true;
            textbox.gameObject.SetActive(true);
            if (_currentTextCount <= _textCount)
            {
                _currentTextCount++;
            }
        }
    }

    public void ReturnUI()
    {
        screenOverlay.texture = screenOverlayTexture;
        GameManager.Instance.imageOverlayOn = false;
        textbox.gameObject.SetActive(false);
    }
}
