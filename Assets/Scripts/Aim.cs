using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private LayerMask _layerMask;

    public void Update()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, _layerMask))
        {
            transform.position = new Vector3(raycastHit.point.x + 1, raycastHit.point.y, raycastHit.point.z);
        }
    }


    



}
