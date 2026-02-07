using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float flySpeed = 10f;
    public int damage = 1;

    void Update()
    {
        transform.position += Vector3.up * flySpeed * Time.deltaTime;
    }

    // Xử lý va chạm gây sát thương
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ❌ Bỏ qua Player (tránh tự bắn mình)
        if (collision.CompareTag("Player"))
            return;

        // Chỉ gây damage cho Enemy
        EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        // Hủy đạn khi va chạm bất kỳ (trừ Player)
        Destroy(gameObject);
    }
}
