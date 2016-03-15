using UnityEngine;

public class GetMoneyController : MonoBehaviour
{
    public int Amount = 100;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MyDispatcher.Dispatch(GameEvents.CHANGE_MONEY, Amount);
            Destroy(gameObject);
        }
    }
}