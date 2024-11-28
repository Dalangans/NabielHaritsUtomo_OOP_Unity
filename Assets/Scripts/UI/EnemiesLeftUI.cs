using UnityEngine;
using UnityEngine.UIElements;

public class EnemiesLeftUI : MonoBehaviour
{
    private CombatManager combatManager;  // Referensi ke CombatManager
    private Label enemiesLeftLabel;  // Referensi ke Label UI Toolkit untuk menampilkan jumlah musuh yang tersisa

    // Start is called before the first frame update
    void Start()
    {
        // Cari referensi ke CombatManager yang ada di scene
        combatManager = FindObjectOfType<CombatManager>();

        // Ambil referensi ke Label 'EnemiesLeft' dari UI Document
        var uiDocument = GetComponent<UIDocument>();
        var rootVisualElement = uiDocument.rootVisualElement;
        enemiesLeftLabel = rootVisualElement.Q<Label>("EnemiesLeft");

        // Pastikan komponen ditemukan
        if (enemiesLeftLabel == null)
        {
            Debug.LogError("Label 'EnemiesLeft' not found in the UI Document.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (combatManager != null && enemiesLeftLabel != null)
        {
            // Dapatkan jumlah musuh yang tersisa
            int enemiesLeft = combatManager.totalEnemies;

            // Update label dengan jumlah musuh yang tersisa
            enemiesLeftLabel.text = "Enemies Left: " + enemiesLeft.ToString();
        }
    }
}
