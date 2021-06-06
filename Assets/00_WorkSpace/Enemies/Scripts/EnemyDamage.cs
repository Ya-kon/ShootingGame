using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    #region public variables
    public int health;
    public int damage;
    #endregion //public variables

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * トリガーイベント
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet") Damage();
    }

    /*
     * ダメージ処理
    */
    void Damage()
    {
        health -= damage;

        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
