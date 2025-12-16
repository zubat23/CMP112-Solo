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
        //Set up listener for button
        upgradeButton.onClick.AddListener(OnUpgradeClicked);
    }

    private void Update()
    {
        //Ensures other upgrades are destroyed when a different one is chosen.
        if (Global.waveActive)
        {
            Destroy(gameObject);
        }
    }
    public void setupUpgrade(int upgradeIndex, string spriteName, string description, float upgradeAmount)
    {
        //Info recieved from GameController, sets up the upgrade.
        index = upgradeIndex;
        spriteImage.sprite = upgradeSprites[upgradeIndex];
        descriptionText.text = description;
        amount = upgradeAmount;
    }

    void OnUpgradeClicked()
    {
        //Applies this upgrade if its chosen, then start next wave.
        switch (index)
        {
            case 0: Global.maxAmmo += amount; break; //gun.GetComponent<GunControls>.ammo += amount; break;
            case 1: Global.bulletDamage += amount; break;
            case 2: Global.maxHealth += amount; break; //player.GetComponent<PlayerMovement>.health += amount; break;
            case 3: Global.playerJumpForceMult += amount; break;
            case 4: Global.bulletPiercing += amount; break;
            case 5: Global.playerSpeedMult += amount; break;
        }
        Global.waveActive = true;
    }
}
