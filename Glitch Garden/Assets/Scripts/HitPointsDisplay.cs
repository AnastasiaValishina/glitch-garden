using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitPointsDisplay : MonoBehaviour
{
    [SerializeField] int hitpoints = 10;
    [SerializeField] int damage = 1;
    Text hitpointsText;
    void Start()
    {
        hitpointsText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        hitpointsText.text = hitpoints.ToString();
    }

    public void RemoveHitpoint()
    {
        hitpoints -= damage;
        UpdateDisplay();

        if (hitpoints <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
