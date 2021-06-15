using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ScoreData 
{
    public int score;

    public ScoreData(ScoreManager scoreManager)
    {
        score = scoreManager.score;
    }
    
}
