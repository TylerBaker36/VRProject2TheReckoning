using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HipPoints : MonoBehaviour
{
    public Image hpBar;

    private float currentHP = 5.0f;
    private float maxHP = 5.0f;

    private void Start()
    {
        hpBar.fillAmount = 1.0f;
        this.GetComponent<Rigidbody>().isKinematic = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            if (currentHP > 1.0f)
            {
                currentHP--;
                hpBar.fillAmount = currentHP / maxHP;
            }
            else if (currentHP == 1.0f)
            {

                Destroy(this.gameObject);
            }
        }
    }
}
