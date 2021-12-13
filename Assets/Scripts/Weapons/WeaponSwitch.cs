using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    
    private int totalWeapons;
    private int weaponIndex;

    public GameObject[] weaponArray;
    [SerializeField] GameObject weapons;
    public GameObject currentWeapon;

    private void Start()
    {
        totalWeapons = weapons.transform.childCount;
        weaponArray = new GameObject[totalWeapons];

        for (int i = 0; i < totalWeapons; i++)
        {
            weaponArray[i] = weapons.transform.GetChild(i).gameObject;
            weaponArray[i].SetActive(false);            
        }

        weaponArray[0].SetActive(true);
        currentWeapon = weaponArray[0];
        weaponIndex = 0;

    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) {
            weaponArray[weaponIndex].SetActive(false);

            if (weaponIndex < totalWeapons - 1)
            {                
                weaponIndex++;
                weaponArray[weaponIndex].SetActive(true);
            }

            else 
            {                
                weaponIndex = 0;
                weaponArray[weaponIndex].SetActive(true);
            }

            currentWeapon = weaponArray[weaponIndex];

        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            weaponArray[weaponIndex].SetActive(false);
            
            if (weaponIndex > 0)
            {
                weaponIndex--;
                weaponArray[weaponIndex].SetActive(true);
            }

            else 
            {
                weaponIndex = totalWeapons - 1;
                weaponArray[weaponIndex].SetActive(true);
            }

            currentWeapon = weaponArray[weaponIndex];
        }
    }
}
