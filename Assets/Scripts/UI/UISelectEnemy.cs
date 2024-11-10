using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISelectEnemy : MonoBehaviour
{
    public EnemyBase enemyBase;

    public GameObject targetIndicator; // Tham chiếu đến UI chỉ báo
    public GameObject infomation_Enemy;

    public Image artEnemy;
    public TMP_Text nameEnemy;
    public TMP_Text damaged;

    private void Start()
    {

        if (targetIndicator != null)
        {
            targetIndicator.SetActive(false);
        }

        if (infomation_Enemy != null)
        {
            infomation_Enemy.SetActive(false);
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

    public void ShowInfomationEnemy()
    {
        if (infomation_Enemy != null)
        {
            infomation_Enemy.SetActive(true);
        }

        artEnemy.sprite = enemyBase.artEnemy;
        nameEnemy.text = enemyBase.name.ToString();
        damaged.text = enemyBase.attack.ToString();

/*        if (healthSlider != null)
        {
            healthSlider.value = currentHP;
        }*/
    }

    public void HideInfomationEnemy()
    {
        if (infomation_Enemy != null)
        {
            infomation_Enemy.SetActive(false);
        }
    }

}
