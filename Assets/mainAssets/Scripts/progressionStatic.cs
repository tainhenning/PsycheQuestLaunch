using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class progressionStatic
{
    private static bool intro1_2, game1_1, game1_2, game1_3, game2_1, game2_2, game2_3, game3, end;
    public static bool Intro1_2 {
        get {return intro1_2;}
        set {intro1_2 = value;}
    }
    public static bool Game1_1 {
        get {return game1_1;}
        set {game1_1 = value;}
    }
    public static bool Game1_2 {
        get {return game1_2;}
        set {game1_2 = value;}
    }
    public static bool Game1_3 {
        get {return game1_3;}
        set {game1_3 = value;}
    }
    public static bool Game2_1 {
        get {return game2_1;}
        set {game2_1 = value;}
    }
    public static bool Game2_2 {
        get {return game2_2;}
        set {game2_2 = value;}
    }
    public static bool Game2_3 {
        get {return game2_3;}
        set {game2_3 = value;}
    }
    public static bool Game3 {
        get {return game3;}
        set {game3 = value;}
    }
    public static bool End {
        get {return end;}
        set {end = value;}
    }    
}
