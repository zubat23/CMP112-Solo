using UnityEditor;
using UnityEngine;

public class Global : MonoBehaviour
{
    //Upgradeable stats
    public static float playerSpeedMult = 1f;
    public static float playerJumpForceMult = 1f;
    public static float bulletDamage = 10f;
    public static float maxAmmo = 6f;
    public static float maxHealth = 30f;
    public static float bulletPiercing = 1f;

    //Wave info
    public static int enemiesRemaining = 0;
    public static int enemiesDefeated = 0;
    public static bool waveActive = true;
}
