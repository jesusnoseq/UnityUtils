using UnityEngine.InputSystem;
using UnityEngine;

// From https://stackoverflow.com/a/66300060/1542778 

public class MouseClicks : MonoBehaviour
{
    [SerializeField]
    private Camera gameCamera; 
    private InputAction click;

    void Awake() 
    {
        click = new InputAction(binding: "<Mouse>/leftButton");
        click.performed += ctx => {
            RaycastHit hit; 
            Vector3 coor = Mouse.current.position.ReadValue();
            if (Physics.Raycast(gameCamera.ScreenPointToRay(coor), out hit)) 
            {
                hit.collider.GetComponent<IClickable>()?.OnClick();
            }
        };
        click.Enable();
    }
}