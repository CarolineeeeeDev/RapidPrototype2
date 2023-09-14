using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : StateMachineBehaviour
{
    [SerializeField] private string[] _sceneToLoad;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        LoadScene(_sceneToLoad);
    }

    private void LoadScene(params string[] scenes)
    {
        string mainScene = scenes[0];
        SceneManager.LoadSceneAsync(mainScene, LoadSceneMode.Single);
        if (scenes.Length > 1)
        {
            for (int i = 1; i < scenes.Length; i++)
            {
                SceneManager.LoadScene(scenes[i], LoadSceneMode.Additive);
            }
        }

    }
}
