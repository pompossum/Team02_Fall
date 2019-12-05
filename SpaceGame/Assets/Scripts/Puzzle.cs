using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jeff Wakeman
//11/25/19
//Placed on every puzzle. Keeps track of what items are needed and sees if they are present in the player's inventory
public class Puzzle : MonoBehaviour
{
    public static string puzzleName;
    public static string[] itemsRequired;
    public static bool completed;

    public static void Check()
    {
    //    if (itemsRequired.Length == 3)
    //    {
    //        completed = GameStatus.GetCurrent().Puzzles(puzzleName, itemsRequired[0], itemsRequired[1], itemsRequired[2]);
    //    }
    //    else if(itemsRequired.Length == 2)
    //    {
    //        completed = GameStatus.GetCurrent().Puzzles(puzzleName, itemsRequired[0], itemsRequired[1]);
    //    }
    //    else
    //    {
    //        completed = GameStatus.GetCurrent().Puzzles(puzzleName, itemsRequired[0]);
    //    }
        
    }
}