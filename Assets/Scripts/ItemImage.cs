using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.UI;

public class ItemImage : ItemText
{
    //Select a Texture in the Inspector to change to
    public RawImage image;
    public RawImage screenOverlay;
    public Texture screenOverlayTexture;

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
        }
    }

    public void ReturnUI()
    {
        screenOverlay.texture = screenOverlayTexture;
        GameManager.Instance.imageOverlayOn = false;
    }
}
