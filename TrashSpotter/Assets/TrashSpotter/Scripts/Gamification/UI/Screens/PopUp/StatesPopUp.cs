using UnityEngine;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class StatesPopUp : PopUp
    {
		[Header("Cutsomisation")]
		[SerializeField] private Text greenoidName = null;
		[SerializeField] private Text totemName = null;
		[SerializeField] private Image totemImage = null;

		[Header("Badges & exploits")]
		[SerializeField] private GameObject badgeContainer = null;
		[SerializeField] private Image exploitLeftImage = null;
		[SerializeField] private Image exploitRightImage = null;

		[Header("Data information")]
		[SerializeField] private Text spotsValue = null;
		[SerializeField] private Text cleanValue = null;
		[SerializeField] private Text operationValue = null;
		[SerializeField] private Text totalAmountDonatedValue = null;
		[SerializeField] private Text defendValue = null;
		[SerializeField] private Text explorationValue = null;
		[SerializeField] private Text adventureValue = null;

		[Header("Button")]
		[SerializeField] private Button adventurfacebookButton = null;
		[SerializeField] private Button backgroundButton = null;

        private void Start()
        {
			adventurfacebookButton.onClick.AddListener(OnClickFacebookButton);
			backgroundButton.onClick.AddListener(OnClickQuit);
		}

        private void OnClickQuit()
        {
			UIManager.Instance.ClosePopUp(this);
        }

        private void OnClickFacebookButton()
        {
			Debug.Log("Shared to facebook");
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

			adventurfacebookButton.onClick.RemoveListener(OnClickFacebookButton);
			backgroundButton.onClick.RemoveListener(OnClickQuit);

		}
    }
}
