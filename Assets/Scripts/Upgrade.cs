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
    public Button upgradeButton;

    private void Start()
    {
        upgradeButton.onClick.AddListener(OnUpgradeClicked);
    }

    private void Update()
    {
        if (Global.waveActive)
        {
            Destroy(gameObject);
        }
    }
    public void setupUpgrade(int upgradeIndex, string spriteName, string description, float upgradeAmount)
    {
        index = upgradeIndex;
        spriteImage.sprite = upgradeSprites[upgradeIndex];
        descriptionText.text = description;
        amount = upgradeAmount;
    }

    void OnUpgradeClicked()
    {
        switch (index)
        {
            case 0: Global.maxAmmo += amount; break;
            case 1: Global.bulletDamage += amount; break;
            case 2: Global.maxHealth += amount; break;
            case 3: Global.playerJumpForceMult += amount; break;
            case 4: Global.bulletPiercing += amount; break;
            case 5: Global.playerSpeedMult += amount; break;
        }
        Global.waveActive = true;
    }
}
