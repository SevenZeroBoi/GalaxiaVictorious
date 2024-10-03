using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewBullets", menuName = "ScriptableObjects/Bullets", order = 0)]
public class SO_PlayerBullets : MonoBehaviour
{
    public string bulletName;
    public GameObject bulletObject;
    public float bulletCooldown;
}
