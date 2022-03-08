using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepsController : MonoBehaviour { 

private AudioSource m_AudioSource;
[SerializeField] private AudioClip m_JumpSound;           
[SerializeField] private AudioClip m_LandSound;
[SerializeField] private AudioClip m_SwimSound;           
private bool m_PreviouslyGrounded;

    // Start is called before the first frame update
    void Start()
    {
    m_AudioSource = GetComponent<AudioSource>();
    }

void OnCollisionEnter(Collision collision)
{

  //  if (collision.gameObject.tag == "Water")
            if (collision.gameObject.CompareTag("Water"))
            {
            PlaySwimmingSound();
    }

   // if (collision.gameObject.tag == "Sand")
            if (collision.gameObject.CompareTag("Sand"))
            {
        PlayLandingSound();
    }
}

    private void PlayLandingSound ()
    {
        m_AudioSource.clip = m_LandSound;
        m_AudioSource.Play();
        }

private void PlayJumpingSound()
{
    m_AudioSource.clip = m_JumpSound;
    m_AudioSource.Play();
}

private void PlaySwimmingSound()
{
    m_AudioSource.clip = m_SwimSound;
    m_AudioSource.Play();
}

// Update is called once per frame
void Update()
    {

    }
}
