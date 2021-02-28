using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitPointsDisplay : MonoBehaviour
{
    [SerializeField] float baseHitpoints = 3;
    [SerializeField] int damage = 1;
    
    float hitpoints;
    Text hitpointsText;

    void Start()
    {
        hitpoints = baseHitpoints - PlayerPrefsController.GetDifficulty();
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
