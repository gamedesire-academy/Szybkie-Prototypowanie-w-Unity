using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	[SerializeField]
	private LifeController lifeController = null;

	private Image healthBarImage;

	public void Start()
	{
		healthBarImage = GetComponent<Image>();
    }

	public void Update()
	{
		healthBarImage.fillAmount = Mathf.Clamp01(lifeController.Life / lifeController.MaxLife);
	}
}