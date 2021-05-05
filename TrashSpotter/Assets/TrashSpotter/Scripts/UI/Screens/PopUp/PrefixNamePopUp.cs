using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class PrefixNamePopUp : PopUp
    {
        [SerializeField] private GameObject nameContainer = null;
        [SerializeField] private GameObject prefixContainer = null;

        private void Start()
        {
            foreach (Toggle item in prefixContainer.transform.GetComponentsInChildren<Toggle>())
            {
                item.onValueChanged.AddListener((value) => ChangePrefix(item.GetComponent<Text>()));
            }
        }

        private void ChangePrefix(Text text)
        {
            for (int i = 0; i < nameContainer.transform.childCount; i++)
            {
                if (nameContainer.transform.GetChild(i).name == "NamePrefix")
                {
                    nameContainer.transform.GetChild(i).GetComponentInChildren<Text>().text = text.text;
                }
            }
        }
    }
}
