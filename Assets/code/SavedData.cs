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

    private int levelAmt = 21;
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
        
        //status of each level
        //Stars, index 20 is bonus level
        stars = new int[levelAmt];
        for (int i = 0; i < levelAmt; i++)
        {
            stars[i] = user.levels[i][0];
        }
        //score, index 20 is bonus level
        score = new int[levelAmt];
        for (int i = 0; i < levelAmt; i++)
        {
            score[i] = user.levels[i][1];
        }        
    }
}
