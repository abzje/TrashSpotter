using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class TrashSpotterMainScreen : Screen
    {
        [SerializeField] private Button backButton = null;
        [SerializeField] private Button profileButton = null;
        [SerializeField] private Text screenTitle = null;

        private void OnClickBack()
        {
            Debug.Log("ok");

            if (UIManager.Instance.currentScreen is PopUp)
            {
                UIManager.Instance.ClosePopUp(UIManager.Instance.currentScreen);
                return;
            }

            UIManager.Instance.SwitchScreen(UIManager.Instance.currentScreen.previousScreen);
        }

        private void OnClickProfile()
        {

        }

        protected override void OnDestroy()
        {
            backButton.onClick.RemoveListener(OnClickBack);
            profileButton.onClick.RemoveListener(OnClickProfile);
        }

        protected GraphicRaycaster m_Raycaster;
        protected PointerEventData m_PointerEventData;
        protected EventSystem m_EventSystem;

        protected virtual void Start()
        {

            Debug.Log(backButton);
            backButton.onClick.AddListener(OnClickBack);
            profileButton.onClick.AddListener(OnClickProfile);

            //Fetch the Raycaster from the GameObject (the Canvas)
            m_Raycaster = GetComponent<GraphicRaycaster>();
            //Fetch the Event System from the Scene
            m_EventSystem = GetComponent<EventSystem>();
        }

        protected void Update()
        {
            
            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = Input.mousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                Debug.Log("Hit " + result.gameObject.name);
            }
        }

    }
}
