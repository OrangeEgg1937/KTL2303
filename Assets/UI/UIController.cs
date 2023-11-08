using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    [Header("Plane")]
    [SerializeField]
    private List<GameObject> plane;

    private void Start()
    {
        gameObject.BroadcastMessage("DisplayInfo", -1);
    }

    // Control the plane display
    public void OnClickEvent(int button_id)
    {
        // Active the selected plane
        plane[button_id].gameObject.SetActive(true);

        // Process their display method
        gameObject.BroadcastMessage("DisplayInfo", button_id); 
    }
}
