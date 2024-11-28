using UnityEngine;
using UnityEngine.UIElements;  // Untuk menggunakan UI Toolkit

public class PointUI : MonoBehaviour
{
    private int totalPoints = 0;  // Total poin yang diperoleh
    private Label pointLabel;  // Referensi ke Label UI Toolkit
    private CombatManager combatManager;  // Referensi ke CombatManager

    // Start is called before the first frame update
    void Start()
    {
        // Ambil referensi ke CombatManager
        combatManager = FindObjectOfType<CombatManager>();  // Cari objek CombatManager di scene

        // Ambil referensi ke Label UI Toolkit untuk poin
        var uiDocument = GetComponent<UIDocument>();
        var rootVisualElement = uiDocument.rootVisualElement;
        pointLabel = rootVisualElement.Q<Label>("Point");

        // Pastikan komponen ditemukan
        if (pointLabel == null)
        {
            Debug.LogError("Label 'Point' not found in the UI Document.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Update label poin dengan total poin
        if (pointLabel != null)
        {
            pointLabel.text = "Point: " + totalPoints.ToString();
        }
    }

    // Fungsi untuk menambah poin berdasarkan level musuh
    public void AddPoints(Enemy enemy)
    {
        // Hitung poin berdasarkan level musuh
        int pointsToAdd = enemy.Level;  // Poin = Level musuh

        // Tambahkan poin yang dihitung ke total
        totalPoints += pointsToAdd;

        // Debug untuk melihat jumlah poin yang diperoleh
        Debug.Log("Points added: " + pointsToAdd + " | Total Points: " + totalPoints);
    }
}
