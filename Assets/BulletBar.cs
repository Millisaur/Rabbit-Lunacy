using UnityEngine;
using UnityEngine.UI;

public class BulletBar : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private Image totalweaponBar;
    [SerializeField] private Image currentweaponBar;

    private void Start()
    {
        totalweaponBar.fillAmount =  weapon.counter / 5;
    }

    private void Update()
    {
        currentweaponBar.fillAmount = weapon.counter / 5;
    }
}
