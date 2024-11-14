using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int level = 1; // Set default level for enemy

    public void SetLevel(int newLevel)
    {
        level = newLevel;
    }
}
