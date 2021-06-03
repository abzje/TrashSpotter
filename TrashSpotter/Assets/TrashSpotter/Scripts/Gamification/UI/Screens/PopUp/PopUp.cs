using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.TrashSpotter
{
    public class PopUp : Screen
    {
        public override void Open()
        {
            animator.SetTrigger("Open");
        }

        public override void Close()
        {
            animator.SetTrigger("Close");
        }
    }
}
