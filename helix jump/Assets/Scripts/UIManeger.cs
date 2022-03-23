using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManeger : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _puanText;
    private void Start() {
        rastgeleEngelSpawn.OnPuanCollected += SetPuanText;
    }
    public void SetPuanText(int puanSayisi)
    {
        _puanText.text = puanSayisi.ToString();
    }
}
