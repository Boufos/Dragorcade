using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip _shlink;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(WaitCoroutine());
    }

    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(0.6f);
        _audio.PlayOneShot(_shlink);
        Destroy(gameObject);
    }
}
