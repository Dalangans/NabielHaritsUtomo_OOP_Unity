using UnityEngine;

[RequireComponent(typeof(Collider2D))] // Memastikan bahwa GameObject dengan komponen ini harus memiliki Collider2D
public class HitboxComponent : MonoBehaviour
{
    [SerializeField] private HealthComponent healthComponent; // Referensi ke HealthComponent yang dapat diatur dari Inspector

    void Awake()
    {
        // Cek apakah healthComponent sudah diatur di inspector
        if (healthComponent == null)
        {
            Debug.LogError("HealthComponent is required but not set in the Inspector", this);
        }
    }

    // Method Damage yang menerima Bullet
    public void Damage(Bullet bullet)
    {
        if (healthComponent != null)
        {
            healthComponent.Subtract(bullet.damage); // Mengurangi healthpoint berdasarkan damage dari Bullet
        }
    }

    // Method Damage yang menerima integer
    public void Damage(int damageAmount)
    {
        if (healthComponent != null)
        {
            healthComponent.Subtract(damageAmount); // Mengurangi healthpoint dengan nilai integer yang diberikan
        }
    }
}
