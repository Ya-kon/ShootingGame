using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    #region private variables
    private bool isDead = false;
    #endregion // private variables


    #region public variables
    public float speed; // 移動量
    public float lifeSpan; //生存時間
    #endregion //public variables

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        lifeSpan = lifeSpan - Time.deltaTime;
        if (lifeSpan < 0)
        {
            isDead = true;
        }

        if (!isDead)
        {
            this.transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
        }
        else
        {
            Destroy(this.gameObject); //とりあえず破壊
        }
    }
}
