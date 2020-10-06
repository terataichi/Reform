using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldFurniture : MonoBehaviour
{
    private Player.Player player_ = null;

    public void Start()
    {
        player_ = this.gameObject.GetComponent<Player.Player>();
    }

    public void HoldUpdate (bool holdFlag)
    {
        if(player_.TargetRange())
        {
            Debug.Log("つかめます");
        }
        if (holdFlag && player_.TargetRange()) 
        {
            player_.Target.transform.SetParent(this.transform);
        }
    }
}
