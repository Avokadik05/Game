using Objects;
using Other.Inventory;
using UnityEngine;
using UnityEngine.Events;

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
        private GameObject _interactPrompt;
        [SerializeField]
        private GameObject _takePrompt;
        [SerializeField]
        private GameObject _flashPrompt;
        [SerializeField]
        private GameObject _dropPrompt;
        public GameObject _errorPrompt;
        [SerializeField]
        private GameObject interactiveCross;
        [SerializeField]
        private CutScene cut;
        [SerializeField]
        private Notes note;
        public UnityEvent noteEvent;
        public UnityEvent _stairs;
        public UnityEvent doorEvent;
        public GameObject DoorObj;

        private void Start()
        {
            interactiveCross.SetActive(false);
            _flashlight.enabled = false;
            cam = Camera.main;
        }

        private void Update()
        {
            Ray(); // создаёт луч
            DrawRay(); // рисует луч
            InteractiveObj(); // объекты с которыми можно взаимодействовать
        }

#region ///RayCast///
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
#endregion
        
        public void OnFlash()
        {
            isFlash = false;
        }

        private void InteractiveObj()
        {
            //ClosedDoor
            if (hit.transform != null && hit.transform.GetComponent<Door>())
            {
                Debug.DrawRay(ray.origin, ray.direction * maxDistanceRay, Color.green);
                if (GameInput.Key.GetKeyDown("Interact"))
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
                if (GameInput.Key.GetKeyDown("Interact"))
                {
                    if(hit.transform.tag == "Glav_Door")
                    {
                        doorEvent.Invoke();
                        //print("Glav_Door it's: " + hit.transform.gameObject);
                        hit.transform.GetComponent<OpenedDoor>().Open();
                        Destroy(DoorObj, 6f);
                    }
                    else
                        hit.transform.GetComponent<OpenedDoor>().Open();
                }
            }

            //Inventory objects
            if (hit.transform != null && hit.transform.GetComponent<ItamLay>())
            {
                if (GameInput.Key.GetKeyDown("Interact"))
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
                if (GameInput.Key.GetKeyDown("Interact"))
                {
                    if (note.isNote)
                    {
                        note.ExitNote();
                        noteEvent.Invoke();
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
                if (GameInput.Key.GetKeyDown("Interact"))
                {
                    hit.transform.GetComponent<Polki>().Open();
                }
            }

            //Stairs
            if (hit.transform != null && hit.transform.GetComponent<Stairs>())
            {
                Debug.DrawRay(ray.origin, ray.direction * maxDistanceRay, Color.green);
                if (GameInput.Key.GetKeyDown("Interact"))
                {
                    _stairs.Invoke();
                }
            }

            //Crosshair
            if (hit.transform != null && hit.transform.GetComponent<Polki>() || hit.transform != null && hit.transform.GetComponent<Notes>() || hit.transform != null && hit.transform.GetComponent<OpenedDoor>() || hit.transform != null && hit.transform.GetComponent<ItamLay>() || hit.transform != null && hit.transform.GetComponent<Door>() || hit.transform != null && hit.transform.GetComponent<Stairs>())
            {
                interactiveCross.SetActive(true);
            }
            else
            {
                interactiveCross.SetActive(false);
            }

#region ///Prompt///
            //Prompt
            if (hit.transform != null && hit.transform.GetComponent<Door>() || hit.transform != null && hit.transform.GetComponent<OpenedDoor>() || hit.transform != null && hit.transform.GetComponent<Notes>() || hit.transform != null && hit.transform.GetComponent<Polki>() || hit.transform != null && hit.transform.GetComponent<Stairs>())
            {
                _interactPrompt.SetActive(true);
            }
            else
            {
                _interactPrompt.SetActive(false);
            }
            
            if (hit.transform != null && hit.transform.GetComponent<ItamLay>())
            {
                _takePrompt.SetActive(true);
            }
            else
            {
                _takePrompt.SetActive(false);
            }

            if (_inventoryPanel.CurrentItem && !_inventoryPanel.CurrentItem.Dropable == false)
            {
                _dropPrompt.SetActive(true);
            }
            else
            {
                _dropPrompt.SetActive(false);
            }
 #endregion
            
            //Flashlight
            if (_inventoryPanel.CurrentItem && _inventoryPanel.CurrentItem == _flashlightData)
            {
                _flashPrompt.SetActive(true);
                if (GameInput.Key.GetKeyDown("Flash"))
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
                _flashPrompt.SetActive(false);
                _flashlight.enabled = false;
                isFlash = false;
            }
        }
    }
}
