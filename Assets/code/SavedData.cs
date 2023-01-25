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
    public SavedData()
    {
        //volumes
        volumeMas = UserData.volumeMas;
        volumeM = UserData.volumeM;
        volumeE = UserData.volumeE;
        //skin is converted to an int, cuz you can't store a gameobject in binary
        skinIndex = UserData.skinIndex;
        showtimer = UserData.showtimer;
        showfieldLines = UserData.showfieldLines;
        unlockedLevel = UserData.unlockedLevel;
        language = UserData.language;
        coinCount = UserData.coinCount;
        
        //status of each level
        //Stars, index 20 is bonus level
        int l = UserData.levels.GetLength(0);
        stars = new int[l];
        for (int i = 0; i < l; i++)
        {
            stars[i] = UserData.levels[i,0];
        }
        //score, index 20 is bonus level
        score = new int[l];
        for (int i = 0; i < l; i++)
        {
            score[i] = UserData.levels[i,1];
        }        
    }
}
