using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Cambio : MonoBehaviour
{
    private Animator transitionAnimator;
    public int numeroEscena;
    void Start() {
        transitionAnimator = GetComponentInChildren<Animator>();
    }
    private void OnTriggerEnter(Collider other){
        if (other.tag == "Player")
        {
 //           SceneManager.LoadScene(numeroEscena);
            StartCoroutine(SceneLoad(numeroEscena));
        }
    }

   public IEnumerator SceneLoad(int sceneIndex)
    {
        transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneIndex);
    }


}
