using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    public Text keysLabel;
    public Image swordIcon;

    public void UpdateKeys(int keys)
    {
        this.keysLabel.text = keys.ToString();
    }

    public void UpdateSword(bool hasSword)
    {
        this.swordIcon.gameObject.SetActive(hasSword);
    }
}
