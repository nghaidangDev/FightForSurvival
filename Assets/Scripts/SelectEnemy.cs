using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectEnemy : MonoBehaviour
{
    public Transform selectedEnemy; // Biến lưu enemy đã chọn
    private UISelectEnemy previousEnemy; // Enemy trước đó

    // Phương thức tìm kiếm enemy gần nhất
    private void SelectNearestEnemy()
    {
        float minDistance = float.MaxValue;
        Transform nearestEnemy = null;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemyObj in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemyObj.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemyObj.transform;
            }
        }

        // Ẩn chỉ báo của enemy trước đó
        if (previousEnemy != null)
        {
            previousEnemy.HideIndicator();
            previousEnemy.HideInfomationEnemy();
        }

        // Cập nhật enemy đã chọn và hiển thị chỉ báo mới
        selectedEnemy = nearestEnemy;
        if (selectedEnemy != null)
        {
            previousEnemy = selectedEnemy.GetComponent<UISelectEnemy>();
            previousEnemy.ShowIndicator();
            previousEnemy.ShowInfomationEnemy();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) // Khi nhấn "Tab"
        {
            SelectNearestEnemy();
        }
    }
}
