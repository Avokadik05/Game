using Objects;
using Other.Inventory;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class Interactive : MonoBehaviour
    {
        [Header("RayCast")]
        [SerializeField]
        private Camera cam;
        [SerializeField]
        private float maxDistanceRay;
        private Ray ray;
        private RaycastHit hit;

        [Header("Inventory")]
        [SerializeField]
        private InventoryPanel _inventoryPanel;
        [SerializeField]
        private ItemData _keyData;
        [SerializeField]
        private ItemData _flashlightData;
        [SerializeField]
        private Light _flashlight;
        private bool isFlash = false;

        [Header("Other")]
        [SerializeField]
        private GameObject interactiveCross;
        [SerializeField]
        private CutScene cut;
        [SerializeField]
        private Notes note;
        
        private void Start()
        {
            interactiveCross.SetActive(false);
            _flashlight.enabled = false;
        }

        private void Update()
        {
            Ray(); // создаёт луч
            DrawRay(); // рисует луч
            InteractiveObj(); // обьекты с которыми можно взаимодействовать
        }

        private void Ray()
        {
            ray = cam.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

        }

        private void DrawRay()
        {
            if (Physics.Raycast(ray, out hit, maxDistanceRay))
            {
                Debug.DrawRay(ray.origin, ray.direction * maxDistanceRay, Color.blue);
            }

            if (hit.transform == null)
            {
                Debug.DrawRay(ray.origin, ray.direction * maxDistanceRay, Color.red);
            }
        }

        private void InteractiveObj()
        {
            //ClosedDoor
            if (hit.transform != null && hit.transform.GetComponent<Door>())
            {
                Debug.DrawRay(ray.origin, ray.direction * maxDistanceRay, Color.green);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (_inventoryPanel.CurrentItem && _inventoryPanel.CurrentItem == _keyData)
                    {
                        hit.transform.GetComponent<Door>().Open();
                    }
                    else if (!_inventoryPanel.CurrentItem || _inventoryPanel.CurrentItem != _keyData)
                    {
                        hit.transform.GetComponent<Door>().Closed();
                    }
                }
            }

            //OpenedDoor
            if (hit.transform != null && hit.transform.GetComponent<OpenedDoor>())
            {
                Debug.DrawRay(ray.origin, ray.direction * maxDistanceRay, Color.green);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.GetComponent<OpenedDoor>().Open();
                }
            }

            //Inventory objects
            if (hit.transform != null && hit.transform.GetComponent<ItamLay>())
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    var itemData = hit.transform.GetComponent<ItamLay>().ItemData;

                    if (_inventoryPanel.TryAddItem(itemData))
                    {
                        Destroy(hit.transform.gameObject);
                    }
                }
            }
            
            //Note
            if (hit.transform != null && hit.transform.GetComponent<Notes>())
            {
                Debug.DrawRay(ray.origin, ray.direction * maxDistanceRay, Color.green);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (note.isNote)
                    {
                        note.ExitNote();
                    }
                    else
                    {
                        note.OnNote();
                    }
                }
            }

            //Polki
            if (hit.transform != null && hit.transform.GetComponent<Polki>())
            {
                Debug.DrawRay(ray.origin, ray.direction * maxDistanceRay, Color.green);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.GetComponent<Polki>().Open();
                }
            }

            //Crosshair
            if (hit.transform != null && hit.transform.GetComponent<Polki>() || hit.transform != null && hit.transform.GetComponent<Notes>() || hit.transform != null && hit.transform.GetComponent<OpenedDoor>() || hit.transform != null && hit.transform.GetComponent<ItamLay>() || hit.transform != null && hit.transform.GetComponent<Door>())
            {
                interactiveCross.SetActive(true);
            }
            else
            {
                interactiveCross.SetActive(false);
            }

            //Flashlight
            if (_inventoryPanel.CurrentItem && _inventoryPanel.CurrentItem == _flashlightData)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    isFlash = !isFlash;

                    if (isFlash)
                    {
                        _flashlight.enabled = true;
                    }
                    else
                    {
                        _flashlight.enabled = false;
                    }
                }
            }
            else if(_inventoryPanel.CurrentItem || _inventoryPanel.CurrentItem != _flashlightData)
            {
                _flashlight.enabled = false;
                isFlash = false;
            }
        }
    }
}
