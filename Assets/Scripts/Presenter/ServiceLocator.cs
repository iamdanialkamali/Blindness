using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    public EventManager eventManager;
    public Ad adManager;
    public BlowPresenter blowPresenter;
    public BlowConfig config;
    public GameConfig gameConfig;
    
    private static ServiceLocator instance;
    public static ServiceLocator Instance;

    private void Awake()
    {
        instance = this;
        
        if (Instance == null)
            Instance = instance;
        else
            Destroy(gameObject);
        
        SetupInterfaces();
    }

    private void SetupInterfaces()
    {
        eventManager = new BasicEventManager();
        adManager = new GoogleAd();
        blowPresenter = gameObject.AddComponent<BlowPresenter>();
        blowPresenter.config = config;
    }
}