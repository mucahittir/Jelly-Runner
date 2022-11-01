using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController
{
    private Vector2
            _startedPos, // hareketin baþladýðý konum
            _delta; // hareketin devam ettiði konum

    private Vector2 _value; // hareket sonucunda yansýtýlan deðer

    public Vector2 GetValue() // Bu fonksiyonumuz karakter hareketini yazdýðýmýz scriptten çaðýrýlacak ve hareket koduna dahil edilecek.
    {
        return _value;
    }
    public float maxDistance = 100f; // kullanýcýnýn hareketinin maksimum ne kadar olacaðý
    public void CustomUpdate()
    {
        if (Input.GetMouseButtonDown(0))
            _startedPos = (Vector2)Input.mousePosition; // baþlangýç konumunu alýyoruz

        if (Input.GetMouseButtonUp(0))
        {
            // Deðerleri sýfýrlýyoruz hareket bittiði zaman
            _delta = Vector2.zero;
            _startedPos = Vector2.zero;
            _value = Vector2.zero;
        }

        if (!Input.GetMouseButton(0)) return; // hareket ediyorsa hesaplamalarý yapýyoruz
        _delta = (Vector2)Input.mousePosition - _startedPos;
        _delta.x = Mathf.Clamp(_delta.x, -maxDistance, maxDistance);
        _delta.y = Mathf.Clamp(_delta.y, -maxDistance, maxDistance);

        _value = _delta / maxDistance;
        _startedPos = (Vector2)Input.mousePosition;
    }
}
