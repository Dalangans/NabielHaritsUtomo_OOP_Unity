using UnityEngine;

public class EnemyHorizontal : Enemy
{
    public float speed = 5f;
    private Vector2 direction;
    private Camera mainCamera;
    private float xMax;

    private void Start()
    {
        // Mendapatkan referensi kamera utama
        mainCamera = Camera.main;

        // Hitung batas layar berdasarkan kamera
        Vector2 screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        xMax = screenBounds.x;

        // Inisialisasi arah gerakan awal
        InitializeDirection();

        // Atur posisi Enemy di bagian atas layar dengan spawn acak
        Respawn();
    }

    private void Update()
    {
        // Gerakan horizontal bolak-balik
        transform.Translate(direction * speed * Time.deltaTime);

        // Periksa posisi dan ubah arah jika mencapai batas layar secara horizontal
        if (Mathf.Abs(transform.position.x) > xMax)
        {
            direction = -direction; // Balik arah gerakan
            transform.position = new Vector2(Mathf.Sign(transform.position.x) * xMax, transform.position.y); // Koreksi posisi
        }
    }

    private void Respawn()
    {
        // Randomize spawn side (left or right) and set direction accordingly
        float yPos = Random.Range(-mainCamera.orthographicSize, mainCamera.orthographicSize);
        if (Random.value > 0.5f)
        {
            transform.position = new Vector2(-xMax, yPos);
            direction = Vector2.right; // Move right
        }
        else
        {
            transform.position = new Vector2(xMax, yPos);
            direction = Vector2.left; // Move left
        }
    }

    private void InitializeDirection()
    {
        // Randomly choose initial direction to start moving
        direction = Random.value > 0.5f ? Vector2.right : Vector2.left;
    }
}
