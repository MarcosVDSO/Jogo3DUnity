using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FireBullets : MonoBehaviour
{

    [SerializeField] private TMP_Text bulletsLeftText;

    public float range = 10f;
    public float bulletsPerClip = 30;

    private float bulletsLeft;

    private void Start()
    {
        bulletsLeft = bulletsPerClip;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, range))
            {
                Hit(hitInfo.point);
            }
        }

        bulletsLeftText.text = bulletsLeft.ToString() + " / " + bulletsPerClip;

    }

    void Hit(Vector3 position)
    {
        GameObject hit = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        hit.transform.position = position;

        hit.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        Destroy(hit, 2f);

    }
}
