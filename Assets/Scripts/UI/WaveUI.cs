using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;  // Untuk menggunakan UI Toolkit

public class WaveUI : MonoBehaviour
{
    private CombatManager combatManager;  // Referensi ke CombatManager
    private Label waveLabel;  // Referensi ke Label UI Toolkit

    // Start is called before the first frame update
    void Start()
    {
        // Ambil referensi ke CombatManager
        combatManager = FindObjectOfType<CombatManager>();

        // Ambil referensi ke Label UI Toolkit di dalam UI Document
        var uiDocument = GetComponent<UIDocument>();
        var rootVisualElement = uiDocument.rootVisualElement;

        // Ambil Label berdasarkan ID atau kelas yang disebut "Wave"
        waveLabel = rootVisualElement.Q<Label>("Wave");

        // Pastikan CombatManager dan Label ditemukan
        if (combatManager == null)
        {
            Debug.LogError("CombatManager not found in the scene.");
        }

        if (waveLabel == null)
        {
            Debug.LogError("Label 'Wave' not found in the UI Document.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Update teks UI dengan waveNumber saat ini
        if (combatManager != null && waveLabel != null)
        {
            waveLabel.text = "Wave: " + combatManager.waveNumber.ToString();
        }
    }
}
