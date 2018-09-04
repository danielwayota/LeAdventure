using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
	public Text keysLabel;

	public void UpdateKeys(int keys) {
		this.keysLabel.text = keys.ToString();
	}
}
