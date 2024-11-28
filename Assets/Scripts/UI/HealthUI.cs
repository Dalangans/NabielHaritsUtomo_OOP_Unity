using UnityEngine;
using UnityEngine.UIElements;  // Untuk menggunakan UI Toolkit

public class HealthUI : MonoBehaviour
{
    private HealthComponent healthComponent;  // Referensi ke HealthComponent
    private Label healthLabel;  // Referensi ke Label UI Toolkit
    private GameObject player; // Referensi ke gameObject player

    // Start is called before the first frame update
    void Start()
    {
        // Mencari objek player di scene
        player = GameObject.FindGameObjectWithTag("Player");
        
        if (player != null)
        {
            healthComponent = player.GetComponent<HealthComponent>();
        }

        // Ambil referensi ke Label UI Toolkit di dalam UI Document
        var uiDocument = GetComponent<UIDocument>();
        var rootVisualElement = uiDocument.rootVisualElement;

        // Ambil Label berdasarkan ID yang disebut "Health"
        healthLabel = rootVisualElement.Q<Label>("Health");

        // Pastikan komponen ditemukan
        if (healthComponent == null)
        {
            Debug.LogError("HealthComponent not found on player object.");
        }

        if (healthLabel == null)
        {
            Debug.LogError("Label 'Health' not found in the UI Document.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Cek jika player sudah dihancurkan
        if (player == null)
        {
            healthLabel.text = "Health: 0";  // Menampilkan Health 0 jika player dihancurkan
        }
        else if (healthComponent != null && healthLabel != null)
        {
            // Update teks UI dengan health saat ini
            int currentHealth = healthComponent.GetHealth();
            if (currentHealth <= 0)
            {
                healthLabel.text = "Health: 0";  // Menampilkan Health 0 jika player mati
            }
            else
            {
                healthLabel.text = "Health: " + currentHealth.ToString();  // Menampilkan health yang sebenarnya
            }
        }
    }
}
