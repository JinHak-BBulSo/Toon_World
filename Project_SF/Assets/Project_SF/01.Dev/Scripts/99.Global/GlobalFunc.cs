using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class GlobalFunc
{
    public static RectTransform GetRect(this GameObject obj_)
    {
        return obj_.GetComponent<RectTransform>();
    }
}
