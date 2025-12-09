using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    private float amount;
    private int index;

    public Sprite[] upgradeSprites;

    public TextMeshProUGUI descriptionText;
    public Image spriteImage;
    public void setupUpgrade(int upgradeIndex, string spriteName, string description, float upgradeAmount)
    {
        spriteImage.sprite = upgradeSprites[upgradeIndex];
        descriptionText.text = description;
        amount = upgradeAmount;
        
    }
}
