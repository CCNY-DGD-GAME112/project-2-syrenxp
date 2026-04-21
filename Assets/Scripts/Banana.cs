using UnityEngine;

public class Banana : Collectable
{
    public float timeBonus = 5f;

    public override void Collect()
    {
    
    GameManager.Instance.AddTime(timeBonus);
    Debug.Log("Banana collected. +5 seconds");

    }
}
