using flanne;
using HarmonyLib;
using System;
using System.Collections.Generic;
using static LocalizationLib.LocalizationLib;

namespace LocalizationLib
{
    /// <summary>
    /// Static Class for Localization Management
    /// </summary>
    public static class LocalizationProvider
    {
        /// <summary>
        /// Dictionary containing all localization dictionaries.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<LocalizationSystem.Language, Dictionary<string, string>> LocalizationDict { get; } = new Dictionary<LocalizationSystem.Language, Dictionary<string, string>>();

        static LocalizationProvider()
        {
            if (!LocalizationSystem.isInit)
            {
                LocalizationSystem.Init();
                Traverse traverse = Traverse.Create(typeof(LocalizationSystem));
                LocalizationDict.Add(LocalizationSystem.Language.English, (Dictionary<string, string>)traverse.Field("localizedEN").GetValue());
                LocalizationDict.Add(LocalizationSystem.Language.Japanese, (Dictionary<string, string>)traverse.Field("localizedJP").GetValue());
                LocalizationDict.Add(LocalizationSystem.Language.Chinese, (Dictionary<string, string>)traverse.Field("localizedCH").GetValue());
                LocalizationDict.Add(LocalizationSystem.Language.BrazilPortuguese, (Dictionary<string, string>)traverse.Field("localizedBR").GetValue());
                LocalizationDict.Add(LocalizationSystem.Language.TChinese, (Dictionary<string, string>)traverse.Field("localizedTC").GetValue());
                LocalizationDict.Add(LocalizationSystem.Language.Russian, (Dictionary<string, string>)traverse.Field("localizedRU").GetValue());
                LocalizationDict.Add(LocalizationSystem.Language.Spanish, (Dictionary<string, string>)traverse.Field("localizedSP").GetValue());
                LocalizationDict.Add(LocalizationSystem.Language.German, (Dictionary<string, string>)traverse.Field("localizedGR").GetValue());
                LocalizationDict.Add(LocalizationSystem.Language.Polish, (Dictionary<string, string>)traverse.Field("localizedPL").GetValue());
                LocalizationDict.Add(LocalizationSystem.Language.Italian, (Dictionary<string, string>)traverse.Field("localizedIT").GetValue());
                LocalizationDict.Add(LocalizationSystem.Language.Turkish, (Dictionary<string, string>)traverse.Field("localizedTR").GetValue());
                LocalizationDict.Add(LocalizationSystem.Language.French, (Dictionary<string, string>)traverse.Field("localizedFR").GetValue());
            }
        }

        /// <summary>
        /// Adds a localization string to the target language if it does not yet exist.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>bool sucess</returns>
        public static bool AddLocalization(LocalizationSystem.Language language, string key, string value)
        {
            Dictionary<string, string> langDict = LocalizationDict[language];
            if (!langDict.ContainsKey(key))
            {
                langDict.Add(key, value);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Adds a localization string to all languages if it does not yet exist.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>bool success</returns>
        public static bool AddLocalizationAll(string key, string value)
        {
            foreach (LocalizationSystem.Language language in Enum.GetValues(typeof(LocalizationSystem.Language)))
            {
                if (!AddLocalization(language, key, value))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Returns a localized string of the target language.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="key"></param>
        /// <returns>string localization</returns>
        public static string GetLocalization(LocalizationSystem.Language language, string key)
        {
            if (LocalizationDict[language].ContainsKey(key))
            {
                return LocalizationDict[language][key];
            }
            else
            {
                Log.LogDebug(Enum.GetName(typeof(LocalizationSystem.Language), language) + " does not contain key " + key);
                return "";
            }
        }

        /// <summary>
        /// Resturns all localizations of a string.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Dictionary&lt;LocalizationSystem.Language, string&gt;</returns>
        public static Dictionary<LocalizationSystem.Language, string> GetLocalizationAll(string key)
        {
            Dictionary<LocalizationSystem.Language, string> localizations = new Dictionary<LocalizationSystem.Language, string>();
            foreach (LocalizationSystem.Language language in Enum.GetValues(typeof(LocalizationSystem.Language)))
            {
                localizations.Add(language, LocalizationDict[language][key]);
            }
            return localizations;
        }

        /// <summary>
        /// Adds or overwrites a localization string to the target language.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetLocalization(LocalizationSystem.Language language, string key, string value)
        {
            LocalizationDict[language][key] = value;
        }

        /// <summary>
        /// Adds or overwrites all localizations of a string.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetLocalizationAll(string key, string value)
        {
            foreach (LocalizationSystem.Language language in Enum.GetValues(typeof(LocalizationSystem.Language)))
            {
                SetLocalization(language, key, value);
            }
        }

        /// <summary>
        /// Returns the localization dictionary of a specific language.
        /// </summary>
        /// <param name="language"></param>
        /// <returns>Dictionary&lt;string, string&gt;</returns>
        public static Dictionary<string, string> GetLanguageDictionary(LocalizationSystem.Language language)
        {
            return LocalizationDict[language];
        }
    }
}