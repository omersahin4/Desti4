using UnityEngine;
using UnityEngine.SceneManagement;

public class MisketOyunController : MonoBehaviour
{
    public MisketController[] misketler;
    public float zamanSiniri = 40.0f;
    private float kalanSure;
    private int kalanAtisHakki = 3;
    private int toplamPuan = 0;
    private bool oyunBitti = false;

    private void Start()
    {
        kalanSure = zamanSiniri;
    }

    private void Update()
    {
        if (!oyunBitti)
        {
            kalanSure -= Time.deltaTime;
            if (kalanSure <= 0)
            {
                OyunuBitir(false);
            }
        }
    }

    public void AtisYapildi()
    {
        kalanAtisHakki--;
        if (kalanAtisHakki <= 0)
        {
            OyunuBitir(false);
        }
    }

    public void MisketiHalkayaGirdi()
    {
        toplamPuan += 30;
        if (toplamPuan >= 180)
        {
            OyunuBitir(true);
        }
    }

    private void OyunuBitir(bool kazandi)
    {
        oyunBitti = true;
        if (kazandi)
        {
            Debug.Log("Oyun kazanýldý!");
        }
        else
        {
            Debug.Log("Oyun kaybedildi!");
        }

        // Oyun sonlandýrma iþlemleri burada yapýlabilir
    }
}
