using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Info", menuName = "ScriptableObjects/Weapon Info", order = 1)]
public class WeaponInfo : ScriptableObject
{
    public int bulletPerMinute;
    public int magazineCapacity;
    public int shootingAccuracy;
    [Tooltip("Bullet Damage")]                  public int damage;
    [Tooltip("Gun Reload Speed")]               public int reload;
    [Tooltip("Bullet Movement Speed")]          public float speed;
    [Tooltip("Bullet Name Key for Dictionary")] public string bulletName;
}
