using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerClickManager : MonoBehaviour
{
    private MoveController MoveController;
    //private AttackController AttackController;

    void Awake()
    {
        MoveController = GetComponent<MoveController>();
        //AttackController = GetComponent<AttackController>();
    }

    void Update()
    {
        if (CanClick() && Input.GetMouseButtonUp(0))
        {
            Ray Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

			/*if (Physics.Raycast(Ray, out hit, 1000f, LayerMask.GetMask("Enemy")))
            {
                AttackController.Attack(hit.collider.gameObject);
            }
            else */
			if (Physics.Raycast(Ray, out hit, 1000f, LayerMask.GetMask("Ground")))
            {                  
                //AttackController.Stop();
                MoveController.Move(hit.point);
            }
        }
    }

    bool CanClick()
    {
		return true;
        //return !EventSystem.current.IsPointerOverGameObject();
    }
}
