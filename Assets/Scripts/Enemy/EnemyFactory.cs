using UnityEngine;

public static class EnemyFactory
{
    public static Enemy CreateEnemy(string enemyType, Vector2 spawnPosition, Transform parentTransform)
    {
        Enemy newEnemy = null;

        switch (enemyType)
        {
            case "BasicEnemy":
                newEnemy = CreateBasicEnemy(spawnPosition, parentTransform);
                break;

            case "HorizontalEnemy":
                newEnemy = CreateHorizontalEnemy(spawnPosition, parentTransform);
                break;

            // Tambahkan lebih banyak tipe enemy di sini jika diperlukan
            default:
                Debug.LogError("Enemy type not recognized.");
                break;
        }

        return newEnemy;
    }

    private static Enemy CreateBasicEnemy(Vector2 spawnPosition, Transform parentTransform)
    {
        GameObject enemyObject = new GameObject("BasicEnemy");
        enemyObject.transform.position = spawnPosition;
        enemyObject.transform.parent = parentTransform;

        Enemy enemy = enemyObject.AddComponent<Enemy>();
        // Tambahkan komponen lain atau properti spesifik untuk BasicEnemy di sini
        return enemy;
    }

    private static Enemy CreateHorizontalEnemy(Vector2 spawnPosition, Transform parentTransform)
    {
        GameObject enemyObject = new GameObject("HorizontalEnemy");
        enemyObject.transform.position = spawnPosition;
        enemyObject.transform.parent = parentTransform;

        EnemyHorizontal enemyHorizontal = enemyObject.AddComponent<EnemyHorizontal>();
        // Tambahkan komponen lain atau properti spesifik untuk EnemyHorizontal di sini
        return enemyHorizontal;
    }
}
