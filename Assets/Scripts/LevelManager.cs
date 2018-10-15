using UnityEngine;
using UnityEngine.SceneManagement;

namespace Rocket
{
    public class LevelManager : MonoBehaviour
    {

        public void LoadLevel(string name)
        {
            SceneManager.LoadScene(name);
        }

    } 
}
