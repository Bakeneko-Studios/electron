using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedData
{
    public int skinIndex;
    public int unlockedLevel;

    public int[] stars;
    public int[] score;

    public bool showfieldLines = false;
    public bool showtimer = false;
    public float volumeMas;
    public float volumeM;
    public float volumeE;    
    public int language;
    public int coinCount;

    //SavedData is a class
    public SavedData (UserData user)
    {
        //volumes
        volumeMas = user.volumeMas;
        volumeM = user.volumeM;
        volumeE = user.volumeE;
        //skin is converted to an int, cuz you can't store a gameobject in binary
        skinIndex = user.skinIndex;
        showtimer = user.showtimer;
        showfieldLines = user.showfieldLines;
        unlockedLevel = user.unlockedLevel;
        language = user.language;
        coinCount = user.coinCount;
        int lvlCount = user.levels.Length;
        
        //status of each level
        //Stars, index 20 is bonus level
        stars = new int[lvlCount];
        for (int i = 0; i < lvlCount; i++)
        {
            stars[i] = user.levels[i,0];
        }
        //score, index 20 is bonus level
        score = new int[lvlCount];
        for (int i = 0; i < lvlCount; i++)
        {
            score[i] = user.levels[i,1];
        }        
    }
}
