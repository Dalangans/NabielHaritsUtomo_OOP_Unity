using UnityEngine;

[RequireComponent(typeof(Collider2D))] // Memastikan bahwa GameObject dengan komponen ini harus memiliki Collider2D
public class AttackComponent : MonoBehaviour
{
    public Bullet bulletPrefab; // Referensi prefab Bullet untuk menembak
    public int damage; // Jumlah damage yang diberikan

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Cek apakah objek yang collide memiliki tag yang sama dengan objek ini
        if (other.gameObject.tag == gameObject.tag)
        {
            return; // Jika tag sama, jangan lakukan apa-apa
        }

        // Cek apakah objek yang collide memiliki HitboxComponent
        HitboxComponent hitbox = other.GetComponent<HitboxComponent>();
        if (hitbox != null)
        {
            // Jika ada, panggil method Damage dengan nilai damage yang ditentukan
            hitbox.Damage(damage);
        }
    }
}
