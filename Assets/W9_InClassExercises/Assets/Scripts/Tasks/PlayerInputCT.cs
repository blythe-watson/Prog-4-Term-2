using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
    public class PlayerInputCT : ConditionTask
    {
        protected override bool OnCheck()
        {
            return Input.anyKey;
        }
    }
}