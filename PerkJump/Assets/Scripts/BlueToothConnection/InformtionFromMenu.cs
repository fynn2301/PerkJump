using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformtionFromMenu : MonoBehaviour
{
    public static int playerIndex = 2;

    public void SetPlayerIndex(int index)
    {
        playerIndex = index;
    }
    public int GetPlayerIndex()
    {
        return playerIndex;
    }

}
