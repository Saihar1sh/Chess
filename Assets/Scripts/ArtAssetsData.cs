using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtAssetsData : MonoBehaviour
{
    #region Singleton Instance
    private static ArtAssetsData instance;
    public static ArtAssetsData Instance { get { return instance; } }
    private void SingletonInstantiate()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null || instance != this)
        {
            Destroy(this);
        }
    }
    #endregion

    public Sprite[] chessSqChecks = new Sprite[2];

    private void Awake()
    {
        SingletonInstantiate();
    }

}
