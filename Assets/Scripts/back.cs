using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back : MonoBehaviour {
    public void Skip() {
        SceneManager.LoadScene("Begin");
    }
    public void HandleExit()
    {
        Application.Quit();//�˳���Ϸ
    }
}
