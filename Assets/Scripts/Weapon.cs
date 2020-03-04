using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon
{
    public string Label;
    public int Price;
    public Sprite Icon;
    public ParticleSystem ShootEffect;
    public bool IsBuy = false;
}
