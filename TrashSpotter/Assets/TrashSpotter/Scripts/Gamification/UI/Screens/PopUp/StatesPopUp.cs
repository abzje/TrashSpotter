using DG.Tweening;
using System.Collections.Generic;
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
		[SerializeField] private Text totalAmountDonatedValue = null;
		[SerializeField] private Text defendValue = null;
		[SerializeField] private Text explorationValue = null;
		[SerializeField] private Text adventureValue = null;

		[Header("Button")]
		[SerializeField] private Button adventurfacebookButton = null;
		[SerializeField] private Button backgroundButton = null;

		[Header("Others")]
		[SerializeField] private Image backgroundImage = null;
		[SerializeField] private Sprite backgroundNavigator = null;
		[SerializeField] private Sprite backgroundGuardian = null;
		[SerializeField] private Sprite backgroundSentries = null;

		private List<Sprite> backgrounds = new List<Sprite>();

		private void Start()
        {
			adventurfacebookButton.onClick.AddListener(OnClickFacebookButton);
			backgroundButton.onClick.AddListener(OnClickQuit);

			backgrounds.Add(backgroundNavigator);
			backgrounds.Add(backgroundGuardian);
			backgrounds.Add(backgroundSentries);
		}

        public override void Open()
        {
            base.Open();

			//Replace this line by the something like : is the user from sentries family ? so use this image
			backgroundImage.sprite = backgrounds[(int)Mathf.Round(Random.Range(0, backgrounds.Count - 0.01f))];

		}

        private void OnClickQuit()
        {
			UIManager.Instance.ClosePopUp(this);
        }

        private void OnClickFacebookButton()
        {
			Debug.Log("Shared to facebook");

			adventurfacebookButton.transform.DOPunchScale(new Vector3(1.2f, 1.2f, 1.2f), 0.25f);
		}

        protected override void OnDestroy()
        {
            base.OnDestroy();

			adventurfacebookButton.onClick.RemoveListener(OnClickFacebookButton);
			backgroundButton.onClick.RemoveListener(OnClickQuit);

		}
    }
}
