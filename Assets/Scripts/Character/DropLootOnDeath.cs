using UnityEngine;

public class DropLootOnDeath : MonoBehaviour
{
    private LifeController lifeController;

    public GameObject dropPrefab;

    public void Start()
    {
        lifeController = GetComponent<LifeController>();
        lifeController.Died += DropLoot;
    }

    public void OnDestroy()
    {
        lifeController.Died -= DropLoot;
    }

    public void DropLoot()
    {
        var loot = GameObject.Instantiate(dropPrefab);
        var distance = Random.insideUnitCircle * 3;
        loot.transform.position = this.transform.position + new Vector3(distance.x, 0, distance.y);
        Destroy(this);
    }
}
