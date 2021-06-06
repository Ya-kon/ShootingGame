using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 移動を管理
*/
public class PlayerMove : MonoBehaviour
{
    #region constant variables
    private const float ZERO_INPUT_VAL = 0.0f;
    private const string XINPUT_NAME = "Horizontal";
    private const string YINPUT_NAME = "Vertical";
    #endregion  //constant variables

    #region  private variables
    private bool isConnectedJoyStick = false; //ゲームパッドが接続されているかどうか
    private Vector2 speed　= new Vector2(0.0f, 0.0f);　//移動量
    #endregion //private variables

    # region public variables
    public float MIN_INPUT_VAL;　//入力除外値
    public float speedMultiply; //スピードに掛ける値
    #endregion  //public variables

    /*
     * 更新処理
    */
    void Update()
    {
        //------------------------------
        // ジョイスティックが接続されているかどうかを判断
        var JoyStickNames = Input.GetJoystickNames();
        if (JoyStickNames[0] == null) isConnectedJoyStick = false;
        else isConnectedJoyStick = true;

        //------------------------------
        // ゲームパッド用入力
        if (isConnectedJoyStick)
        {
            speed.x = Input.GetAxis(XINPUT_NAME);
            speed.y = Input.GetAxis(YINPUT_NAME);

            //スティック入力値が最低入力値より小さいなら無視
            if (speed.x < MIN_INPUT_VAL && speed.x > -MIN_INPUT_VAL && speed.y < MIN_INPUT_VAL && speed.y > -MIN_INPUT_VAL)
            {
                speed.x = ZERO_INPUT_VAL;
                speed.y = ZERO_INPUT_VAL;
            }

        }
        //------------------------------
        // キーボード用入力
        else if (!isConnectedJoyStick)
        {
            speed.x = Input.GetAxisRaw(XINPUT_NAME);
            speed.y = Input.GetAxisRaw(YINPUT_NAME);
        }

        speed.Normalize(); //正規化

        this.transform.Translate( (speed.x * speedMultiply) * Time.deltaTime, (speed.y * speedMultiply) * Time.deltaTime, 0.0f);　//移動
    }
}
