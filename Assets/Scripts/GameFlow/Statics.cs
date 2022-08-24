using UnityEngine;

public class Statics
{
    // variables/constants
    public static int currentLevel;
    public static float enemySpeed;
    public static float enemySpawnRate;
    // methods
    public static Vector2 randomSpawnLocation()
    {
        float x = 0.0f; 
        float y = 0.0f;

        switch(Random.Range(0,4))
        {
            case 0: // left
                x = -12.0f;
                y = Random.Range(-6.0f, 5.0f);
                break;
            case 1: // right
                x = 12.0f;
                y = Random.Range(-6.0f, 5.0f);
                break;
            case 2: // up
                x = Random.Range(-11.0f, 11.0f);
                y = 6.0f;
                break;
            case 3: // down
                x = Random.Range(-11.0f, 11.0f);
                y = -6.0f;
                break;
        }
        Vector2 location = new Vector2(x, y);
        return location;
    }
}