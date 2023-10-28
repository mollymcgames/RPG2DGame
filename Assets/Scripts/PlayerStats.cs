using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class PlayerStats : MonoBehaviour
{

    public int level = 1;
    public int maxLevel = 100; //max level we can reach
    public TMP_Text levelText;
    public int currentExp;  //how much experience we have
    public int baseExp = 1000; 
    public int[] expToNextLevel; //how much experience we need to get to the next level to make a list of different elements


    // Start is called before the first frame update
    void Start()
    {
        levelText.text = "Level: " + level; //display level on screen
        expToNextLevel = new int[maxLevel]; //create a new array of integers
        expToNextLevel[1] = baseExp; //set the first element of the array to the base experience
        //fill the array with the experience needed to get to the next level using a for loop
        for (int i = 2; i < expToNextLevel.Length; i++)  //set to second element of the array to the base experience
        {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f); //increase the experience needed to get to the next level by 5%
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GainExperience(int experienceGained)
    {
        currentExp += experienceGained; //add the experience we gained to the current experience
        if(level < maxLevel) //if we haven't reached the max level
        {
            if(currentExp >= expToNextLevel[level] && level < maxLevel) //if we have enough experience to level up
            {
                currentExp -= Mathf.Max(0, currentExp - expToNextLevel[level]); //subtract the experience needed to level up from the current experience
                level++; //increase the level
                levelText.text = "Level: " + level; //display the new level on screen
                Debug.Log("Level Up! New Level: " + level); // Add this line to log the new level
            }
        }
    Debug.Log("Current Exp: " + currentExp); // Add this line to log the current experience
    }

}
