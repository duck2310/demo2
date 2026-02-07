using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. Thay 'MonoBehaviour' bằng 'Health' để kế thừa
public class EnemyHealth : Health
{
    // 2. Xóa biến explosionPrefab (vì lớp Health đã có rồi)

    // 3. Xóa OnTriggerEnter2D (vì lớp Health đã xử lý rồi)

    // 4. Ghi đè hàm Die() để in log theo yêu cầu (trang 7)
    protected override void Die()
    {
        base.Die(); // Chạy lệnh nổ và hủy của lớp cha
        Debug.Log("Enemy died"); // In thông báo riêng
    }
}