using UnityEngine;

public class PotionShopController : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MyDispatcher.Dispatch(GameEvents.SHOP_IS_NEAR);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            MyDispatcher.Dispatch(GameEvents.SHOP_IS_NO_LONGER_NEAR);
        }
    }
}
