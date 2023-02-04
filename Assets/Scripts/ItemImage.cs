using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class ItemImage : ItemText
{
    //Select a Texture in the Inspector to change to
    public RawImage image;
    public RawImage screenOverlay;
    public Texture screenOverlayTexture;
    public TMP_Text textbox;

    public void Start()
    {
        textbox.text = imageText;
    }

    public void HandleUI()
    {
        if (GameManager.Instance.imageOverlayOn)
        {
            ReturnUI();
        }
        else
        {
            screenOverlay.texture = image.texture;
            GameManager.Instance.imageOverlayOn = true;
            textbox.gameObject.SetActive(true);
        }
    }

    public void ReturnUI()
    {
        screenOverlay.texture = screenOverlayTexture;
        GameManager.Instance.imageOverlayOn = false;
        textbox.gameObject.SetActive(false);
    }
}
