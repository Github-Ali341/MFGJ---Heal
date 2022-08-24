using UnityEngine;

namespace Heal.Serialization
{
    public static class PlayerPrefsSaveSystem
    {
        public static void SaveFloatToPlayerPrefs (float value, string key)
        {
            PlayerPrefs.SetFloat(key, value);
            PlayerPrefs.Save();
        }

        public static void SaveIntToPlayerPrefs (int value, string key)
        {
            PlayerPrefs.SetInt(key, value);
            PlayerPrefs.Save();
        }

        public static void SaveStringToPlayerPrefs (string value, string key)
        {
            PlayerPrefs.SetString(key, value);
            PlayerPrefs.Save();
        }

        public static float LoadFloatFromPlayerPrefs (string key)
        {
            return PlayerPrefs.GetFloat(key);
        }

        public static int LoadIntFromPlayerPrefs (string key)
        {
            return PlayerPrefs.GetInt(key);
        }

        public static string LoadStringFromPlayerPrefs (string key)
        {
            return PlayerPrefs.GetString(key);
        }
    } 
}
