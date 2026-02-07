using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject explosionPrefab;
    public int defaultHealthPoint;
    private int healthPoint;

    // Khởi tạo máu ban đầu (trang 9)
    private void Start() => healthPoint = defaultHealthPoint;

    // Hàm va chạm tự hủy dùng tạm (trang 8)
    public void OnTriggerEnter2D(Collider2D collision) => Die();

    public void TakeDamage(int damage)
    {
        if (healthPoint <= 0) return; // Kiểm tra máu trước khi trừ

        healthPoint -= damage;
        if (healthPoint <= 0) Die();
    }

    // Hàm ảo để các lớp con có thể ghi đè (trang 8)
    protected virtual void Die()
    {
        if (explosionPrefab != null)
        {
            // Tạo hiệu ứng nổ (trang 8, 2)
            var explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(explosion, 1); // Xóa hiệu ứng sau 1 giây (như trong hình bạn gửi)
        }
        Destroy(gameObject); // Hủy đối tượng
    }
}