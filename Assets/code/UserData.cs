public static class UserData
{
    //data not need to save
    public static int beforeSettings;
    public static bool reloadActivate = true;

    //data need to be saved
    //Volumes, they are not used, just for saving 
    public static float volumeMas;
    public static float volumeM;
    public static float volumeE;
    public static int language;
    public static int skinIndex=0;
    public static bool[] unlockedSkins = new bool[8];
    public static int unlockedLevel;
    public static int[,] levels = new int[21,2]{{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0}};
    // public List<int[]> levels = new List<int[]>
    // {
    //     new int[2] {0,0},  //level 1
    //     new int[2] {0,0},  //level 2
    //     new int[2] {0,0},  //level 3
    //     new int[2] {0,0},  //level 4
    //     new int[2] {0,0},  //level 5
    //     new int[2] {0,0},  //level 6
    //     new int[2] {0,0},  //level 7
    //     new int[2] {0,0},  //level 8
    //     new int[2] {0,0},  //level 9
    //     new int[2] {0,0},  //level 10
    //     new int[2] {0,0},  //level 11
    //     new int[2] {0,0},  //level 12
    //     new int[2] {0,0},  //level 13
    //     new int[2] {0,0},  //level 14
    //     new int[2] {0,0},  //level 15
    //     new int[2] {0,0},  //level 16
    //     new int[2] {0,0},  //level 17
    //     new int[2] {0,0},  //level 18
    //     new int[2] {0,0},  //level 19
    //     new int[2] {0,0},  //level 20
    //     new int[2] {0,0},  //level bonus
    // };
    public static int coinCount=0;
    public static bool showfieldLines = false;
    public static bool showtimer = false;
}
