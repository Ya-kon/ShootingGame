using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 攻撃を管理
*/
public class PlayerAttack : MonoBehaviour
{
    #region constant variables
    private const string BULLET_NAME = "Bullet";
    private const string ATTACK_BTN = "Fire1";
    #endregion //constant variables

    #region private variables
    private GameObject Bullet = null;
    private float shotPerSecondTimer = 0.0f;
    private bool isSingleShot = true; //単発撃ちかどうか
    #endregion //private variables

    #region public variables
    public float shotsPerSecondTime;
    #endregion //public variables

    /*
     * 初期化処理 
    */
    void Start()
    {
        Bullet = (GameObject)Resources.Load(BULLET_NAME); //とりあえずResouce.Loadを使う
        shotPerSecondTimer = shotsPerSecondTime;
    }

    /*
     * 更新処理
    */
    void Update()
    {
        //------------------------------
        // 連続撃ち用入力
        if (Input.GetButton(ATTACK_BTN))
        {
            shotPerSecondTimer -= Time.deltaTime;

            if(shotPerSecondTimer <= 0)
            {
                isSingleShot = false;
                //弾を発射
                Instantiate(Bullet, this.transform.position, Quaternion.identity);
                shotPerSecondTimer = shotsPerSecondTime;
            }
        }

        //------------------------------
        // 単発撃ち用入力
        if (Input.GetButtonUp(ATTACK_BTN))
        {
            if (isSingleShot)
            {
                if (shotPerSecondTimer > 0) Instantiate(Bullet, this.transform.position, Quaternion.identity);
            }

            shotPerSecondTimer = shotsPerSecondTime;
            isSingleShot = true;
        }
    }
}
