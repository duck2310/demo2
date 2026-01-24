using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bulletPrefabs;
    public float shootingInterval = 0.2f; // Đã thêm giá trị mặc định
    public float moveSpeed = 20f;         // Tốc độ di chuyển
    private float lastBulletTime;

    void Update()
    {
        // --- PHẦN 1: DI CHUYỂN THEO CHUỘT ---
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(Camera.main.transform.position.z);
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mousePos);
        worldPoint.z = 0;

        // Di chuyển mượt mà tới vị trí chuột
        transform.position = Vector3.MoveTowards(transform.position, worldPoint, moveSpeed * Time.deltaTime);

        // --- PHẦN 2: BẮN ĐẠN ---
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
            Instantiate(bulletPrefabs, transform.position, transform.rotation);
        }
    }
}