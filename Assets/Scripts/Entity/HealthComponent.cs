using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int maxHealth;  // Maksimum healthpoint yang dapat dimiliki oleh objek
    [SerializeField] private int health;  // Healthpoint saat ini dari objek

    void Start()
    {
        health = maxHealth;  // Menginisialisasi healthpoint dengan nilai maksimum pada saat objek dibuat
    }

    // Getter untuk mendapatkan nilai healthpoint saat ini
    public int GetHealth()
    {
        return health;
    }

    // Fungsi untuk mengurangi healthpoint
    public void Subtract(int damage)
    {
        Debug.Log("KONTOL KONTOL KONTOL");
        health -= damage;  // Mengurangi healthpoint berdasarkan nilai damage yang diberikan
        if (health <= 0)
        {
            Destroy(gameObject);  // Memanggil fungsi DestroyObject jika healthpoint kurang dari atau sama dengan nol
        }
    }
}