using Objects;
using Other.Inventory;
using UnityEngine;

namespace Player
{
    public class Interactive : MonoBehaviour
    {
        [SerializeField] private Camera cam;
        private Ray ray;
        private RaycastHit hit;
        [SerializeField] private GameObject interactiveCross;

        [SerializeField] private float maxDistanceRay;
        private bool isNote = false;
        private Keys keys;
        [SerializeField]
        private SaveSystem ss;

        [SerializeField]
        private InventoryPanel _inventoryPanel;

        [SerializeField]
        private ItemData _keyData;

        private void Start()
        {
            interactiveCross.SetActive(false);
        }

        private void Update()
        {
            Ray();
            DrawRay();
            InteractiveObj();
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
            //Door
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
            else if (hit.transform != null && hit.transform.GetComponent<ItamLay>())
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    var itemData = hit.transform.GetComponent<ItamLay>().ItemData;

                    if (_inventoryPanel.TryAddItem(itemData))
                    {
                        Destroy(hit.transform.gameObject);
                        ss.isDesKey = true;
                    }


                    //print(itemData.Name);
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
            
            //Note
            if (hit.transform != null && hit.transform.GetComponent<Notes>())
            {
                Debug.DrawRay(ray.origin, ray.direction * maxDistanceRay, Color.green);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    isNote = !isNote;

                    if (isNote)
                    {
                        hit.transform.GetComponent<Notes>().OnNote();
                    }
                    else
                    {
                        hit.transform.GetComponent<Notes>().ExitNote();
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

            if (hit.transform != null && hit.transform.GetComponent<Polki>() || hit.transform.GetComponent<Notes>() || hit.transform.GetComponent<OpenedDoor>() || hit.transform.GetComponent<ItamLay>() || hit.transform.GetComponent<Door>())
            {
                interactiveCross.SetActive(true);
            }
            else
            {
                interactiveCross.SetActive(false);
            }
        }
    }
}
