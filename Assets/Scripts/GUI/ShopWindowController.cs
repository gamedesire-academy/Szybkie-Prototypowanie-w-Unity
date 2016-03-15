using UnityEngine;

public class ShopWindowController : MonoBehaviour
{
    [SerializeField]
    private GameObject View;

    public void Awake()
    {
        MyDispatcher.AddListener(GameEvents.SHOP_IS_NEAR, onShopIsNear);
        MyDispatcher.AddListener(GameEvents.SHOP_IS_NO_LONGER_NEAR, onShopIsNoLongerNear);
    }

    public void OnDestroy()
    {
        MyDispatcher.RemoveListener(GameEvents.SHOP_IS_NEAR, onShopIsNear);
        MyDispatcher.RemoveListener(GameEvents.SHOP_IS_NO_LONGER_NEAR, onShopIsNoLongerNear);
    }

    private void onShopIsNear(object iEvent)
    {
        View.SetActive(true);
    }

    private void onShopIsNoLongerNear(object iEvent)
    {
        View.SetActive(false);
    }
}

