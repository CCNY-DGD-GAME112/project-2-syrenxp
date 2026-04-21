using UnityEngine;

public class GoldenBanana : Collectable
{
    public float timeBonus = 10f;

    public override void Collect()
    {
    
    GameManager.Instance.AddTime(timeBonus);
    Debug.Log("Golden Banana collected. +10 seconds");

    }
}
