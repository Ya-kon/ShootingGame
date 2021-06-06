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
    private float shotspersecond;  //内部で確認する用
    #endregion //private variables

    #region public variables
    public float shotsPerSecond;
    #endregion //public variables

    /*
     * 初期化処理 
    */
    void Start()
    {
        Bullet = (GameObject)Resources.Load(BULLET_NAME); //とりあえずResouce.Loadを使う
        shotspersecond = shotsPerSecond;
    }

    /*
     * 更新処理
    */
    void Update()
    {
        if(Input.GetButton(ATTACK_BTN))
        {
            shotspersecond -= Time.deltaTime;

            if(shotspersecond < 0)
            {
                //弾を発射
                Instantiate(Bullet, this.transform.position, Quaternion.identity);
                shotspersecond = shotsPerSecond;
            }
        }
    }
}
