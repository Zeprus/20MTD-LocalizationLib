# <b>LocalizationLib</b>
A [BepInEx](https://github.com/BepInEx/BepInEx/releases) library for [20 Minutes Till Dawn](https://store.steampowered.com/app/1966900/20_Minutes_Till_Dawn/).<br>
Programmatically manage Localizations in 20 Minutes Till Dawn.

----
# <b>Documentation</b>
## static class <b>LocalizationProvider</b>
- ### static Dictionary<LocalizationSystem.Language, Dictionary<string, string>> LocalizationDict { get; }
    Contains all localization dictionaries from flanne.LocalizationSystem<br><br>

- ### static bool AddLocalization(LocalizationSystem.Language language, string key, string value)
    Adds a localization string to the target language if it does not yet exist.<br><br>

- ### static bool AddLocalizationAll(string key, string value)
    Adds a localization string to all languages if it does not yet exist.<br><br>

- ### static string GetLocalization(LocalizationSystem.Language language, string key)
    Returns a localized string of the target language.<br><br>

- ### static Dictionary<LocalizationSystem.Language, string> GetLocalizationAll(string key)
    Resturns all localizations of a string.<br><br>

- ### static void SetLocalization(LocalizationSystem.Language language, string key, string value)
    Adds or overwrites a localization string to the target language.<br><br>

- ### static void SetLocalizationAll(string key, string value)
    Adds or overwrites all localizations of a string.<br><br>

- ### static Dictionary<string, string> GetLanguageDictionary(LocalizationSystem.Language language)
    Returns the localization dictionary of a specific language.