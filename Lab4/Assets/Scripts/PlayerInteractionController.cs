using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerInteractionController : MonoBehaviour
{
    [SerializeField]
    private Sprite whiteCrosshair;

    [SerializeField]
    private Sprite redCrosshair;

    [SerializeField]
    private Image image;

    private GraphicRaycaster graphicRaycaster;

    private void Start()
    {
        graphicRaycaster = gameObject.AddComponent<GraphicRaycaster>();
    }

    void Update()
    {
        PhysicsRaycasts();
        GraphicsRaycaster();
    }

    void PhysicsRaycasts()
    {
        Vector3 centreOfScreen = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0);
        Ray centreOfScreenRay = Camera.main.ScreenPointToRay(centreOfScreen);

        float distanceToFireRay = 20;
        RaycastHit hit;

        image.sprite = whiteCrosshair;

        if (Physics.Raycast(centreOfScreenRay, out hit, distanceToFireRay, ~LayerMask.GetMask("SeeThrough")))
        {
            InteractiveObjectBase interactiveObjectBase = hit.collider.GetComponent<InteractiveObjectBase>();

            if (interactiveObjectBase == null)
            {
                return;
            }
            else
            {
                image.sprite = redCrosshair;
            }

            if (Input.GetMouseButtonDown(0))
            {
                interactiveObjectBase.OnInteraction(true);
            }
        }
    }

    void GraphicsRaycaster()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);

        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(eventData, results);
        bool hitButton = false;

        if (results.Count > 0)
        {
            for (int i = 0; i < results.Count; i++)
            {
                Button button = results[i].gameObject.GetComponent<Button>();
                if (button != null)
                {
                    hitButton = true;
                    if (Input.GetMouseButtonDown(0)) button.onClick.Invoke();
                }

                if (hitButton)
                {
                    InteractiveObjectBase interactiveObjectBase = results[i].gameObject.GetComponent<InteractiveObjectBase>();

                    if (interactiveObjectBase != null)
                    {
                        interactiveObjectBase.OnInteraction(true);
                    }
                }
            }
        }
    }
}
