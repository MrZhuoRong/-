using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class begin : MonoBehaviour {
    public void Skip() {
        SceneManager.LoadScene("Game");
    }

    public void HandleExit()
    {
        Application.Quit();//ÍË³öÓÎÏ·
    }
}
