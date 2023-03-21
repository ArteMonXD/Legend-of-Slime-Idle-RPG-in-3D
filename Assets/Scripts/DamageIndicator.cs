using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIndicator : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _text;
    [SerializeField] private new Animation animation;
    void Start()
    {
        
    }

    void Update()
    {
        if (animation.isPlaying == false)
            Diactive();
    }

    public void Active(int value)
    {
        _text.text = value.ToString();
        animation.Play();
        gameObject.SetActive(true);
    }
    private void Diactive()
    {
        animation.Stop();
        gameObject.SetActive(false);
    }
}
