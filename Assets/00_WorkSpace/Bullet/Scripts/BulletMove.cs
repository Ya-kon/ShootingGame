using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    #region private variables
    private bool isKill = false; // 死滅しているかどうか
    #endregion // private variables


    #region public variables
    public float speed; // 移動量
    public float lifeSpan; //生存時間
    #endregion //public variables

    /*
     * 更新処理
    */
    void Update()
    {
        lifeSpan = lifeSpan - Time.deltaTime;
        if (lifeSpan < 0)
        {
            isKill = true;
        }

        if (!isKill)
        {
            this.transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
        }
        else
        {
            Destroy(this.gameObject); //とりあえず破壊
        }
    }
}
