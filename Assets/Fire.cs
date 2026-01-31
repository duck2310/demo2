using UnityEngine;

public class Fire : MonoBehaviour
{
    [Header("Settings")]
    public GameObject bulletPrefabs;    // Ô "Bullet Prefabs"
    public float shootingInterval = 0.1f; // Ô "Shooting Interval"
    public Vector3 bulletOffset;        // Ô "Bullet Offset" (X, Y, Z)

    [Header("Movement")]
    public float moveSpeed = 20f;

    private float lastBulletTime;

    void Update()
    {
        // --- DI CHUYỂN THEO CHUỘT ---
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(Camera.main.transform.position.z);
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mousePos);
        worldPoint.z = 0;
        transform.position = Vector3.MoveTowards(transform.position, worldPoint, moveSpeed * Time.deltaTime);

        // --- BẮN ĐẠN ---
        if (Input.GetMouseButton(0))
        {
            if (Time.time - lastBulletTime > shootingInterval)
            {
                ShootBullet();
                lastBulletTime = Time.time;
            }
        }
    }

    private void ShootBullet()
    {
        if (bulletPrefabs != null)
        {
            // Tính toán vị trí bắn dựa trên vị trí máy bay + Offset
            // Offset này bạn sẽ chỉnh Y = 0.7 như trong hình để đạn ra ở đầu
            Vector3 firePosition = transform.TransformPoint(bulletOffset);

            GameObject bullet = Instantiate(bulletPrefabs, firePosition, transform.rotation);

            // Thêm lực đẩy đạn bay lên
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * 15f; // Tốc độ đạn
            }

            Destroy(bullet, 4f);
        }
    }
}