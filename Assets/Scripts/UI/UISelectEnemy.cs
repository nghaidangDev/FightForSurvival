using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelectEnemy : MonoBehaviour
{
    public GameObject targetIndicator; // Tham chiếu đến UI chỉ báo

    private void Start()
    {
        if (targetIndicator != null)
        {
            targetIndicator.SetActive(false); // Ẩn chỉ báo khi bắt đầu
        }
    }

    // Bật chỉ báo
    public void ShowIndicator()
    {
        if (targetIndicator != null)
        {
            targetIndicator.SetActive(true);
        }
    }

    // Tắt chỉ báo
    public void HideIndicator()
    {
        if (targetIndicator != null)
        {
            targetIndicator.SetActive(false);
        }
    }
}
