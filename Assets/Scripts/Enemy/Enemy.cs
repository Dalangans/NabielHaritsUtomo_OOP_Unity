using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Level;  // Level musuh (misalnya, 1 untuk level 1, 2 untuk level 2, dst.)

    public EnemySpawner enemySpawner;
    public CombatManager combatManager;

    private void OnDestroy()
    {
        // Memanggil onDeath dari CombatManager dan EnemySpawner
        if (enemySpawner != null && combatManager != null)
        {
            enemySpawner.onDeath();
            combatManager.onDeath();
        }

        // Menambahkan poin berdasarkan level musuh
        PointUI pointSystem = FindObjectOfType<PointUI>();  // Mencari objek Point di scene
        if (pointSystem != null)
        {
            pointSystem.AddPoints(this);  // Panggil AddPoints di Point dengan tipe musuh ini
        }
    }
}
