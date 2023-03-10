using UnityEngine;

public class ItemText : MonoBehaviour
{
    [SerializeField] private string initialText;
    [SerializeField] private string secondText;
    [SerializeField] private string thirdText;
    [SerializeField] public int textCount;
    [SerializeField] protected string imageText;

    [HideInInspector] public string text;
    [HideInInspector] public int count;

    private void Start()
    {
        text = initialText;
        count = 0;
    }

    public void UpdateText(int count)
    {
        switch (count)
        {
            case 0:
                text = secondText;
                break;
            case 1:
                text = thirdText;
                break;
            default:
                break;
        }
    }

    public void CheckForTextUpdate()
    {
        if (textCount > 0 && count < textCount)
        {
            UpdateText(count);
            count++;
        }
    }
}
