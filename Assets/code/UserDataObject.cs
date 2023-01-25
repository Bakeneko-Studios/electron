using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class UserDataObject : MonoBehaviour
{
    void Awake()
    {
        GameObject[] dataCarriers = GameObject.FindGameObjectsWithTag("user data");
        if (dataCarriers.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    IEnumerator Start() {
        if (UserData.language == 0) {
            if (Application.systemLanguage == SystemLanguage.Chinese) {
                UserData.language = 2;
            }
            else {
                UserData.language = 1;
            }
        }
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[UserData.language - 1];
    }
}