using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController
{
    private Vector2
            _startedPos, // hareketin ba�lad��� konum
            _delta; // hareketin devam etti�i konum

    private Vector2 _value; // hareket sonucunda yans�t�lan de�er

    public Vector2 GetValue() // Bu fonksiyonumuz karakter hareketini yazd���m�z scriptten �a��r�lacak ve hareket koduna dahil edilecek.
    {
        return _value;
    }
    public float maxDistance = 100f; // kullan�c�n�n hareketinin maksimum ne kadar olaca��
    public void CustomUpdate()
    {
        if (Input.GetMouseButtonDown(0))
            _startedPos = (Vector2)Input.mousePosition; // ba�lang�� konumunu al�yoruz

        if (Input.GetMouseButtonUp(0))
        {
            // De�erleri s�f�rl�yoruz hareket bitti�i zaman
            _delta = Vector2.zero;
            _startedPos = Vector2.zero;
            _value = Vector2.zero;
        }

        if (!Input.GetMouseButton(0)) return; // hareket ediyorsa hesaplamalar� yap�yoruz
        _delta = (Vector2)Input.mousePosition - _startedPos;
        _delta.x = Mathf.Clamp(_delta.x, -maxDistance, maxDistance);
        _delta.y = Mathf.Clamp(_delta.y, -maxDistance, maxDistance);

        _value = _delta / maxDistance;
        _startedPos = (Vector2)Input.mousePosition;
    }
}
