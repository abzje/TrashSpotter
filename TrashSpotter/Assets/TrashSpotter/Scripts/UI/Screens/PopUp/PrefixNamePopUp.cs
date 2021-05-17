using UnityEngine;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class PrefixNamePopUp : NamePopUp
    {
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
            custoScreen.anteNameButton.transform.GetChild(0).GetComponentInChildren<Text>().text = text.text;
        }
    }
}
