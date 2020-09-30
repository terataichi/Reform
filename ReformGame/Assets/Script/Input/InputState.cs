using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputState : MonoBehaviour
{
    protected Dictionary<(bool now, bool old),INPUT_ID> inputList_ = new Dictionary<(bool,bool), INPUT_ID>();     // INPUT_IDに対応した、ボタン押下格納先
    protected (Vector2 now, Vector2 old) analogInputL_;              // 左スティックの入力状態  
    protected (Vector2 now, Vector2 old) analogInputR_;              // 右スティックの入力状態 

    public InputState()
    {
        for()
        {

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
