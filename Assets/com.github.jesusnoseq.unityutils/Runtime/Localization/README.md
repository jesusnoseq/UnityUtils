# Localization

A solution to handle localization of text and text components (Unity.UI.Text and TMPro.TextMeshProUGUI).

## Usage
Add LocalizationManager and LocalizationStartupManager prefabs to your scene.
Create/edit json files for each language with this format
```
{
    "items": [
        {
            "key": "game_title",
            "value": "Your game title"
        },
		...
	]
}
```

Note:Laguage files should be on /Resources folder.
Note2: Only one language per file.

**Example of use with code**
```csharp
LocalizationManager.Instance.GetLocalizedValue(key);
```

## How to start using this asset
Add component LocalizationStartupManager and LocalizationManager to a scene.
LocalizationStartupManager will initialice LocalizationManager automaticaly at start.
LocalizationManager has options to configure a default language if Application.systemLanguage fails and define what languages are available.
There are another options like WaitUtilFileLoaded to wait the load of the language file or not, to fail if the file is not loaded


## How to localize a text component (or a TMP text component)
Add Localized Text componet to a text componend and write a key, 
the value of that key will reemplace text of the component.


## How to add a new language
Create a file json on /Resources folder.
Use the same json structure as the examples to fill the file.
Configure LocalizationManager adding a new item to Language Files array.
Two new fields should appear, Language and Filename;
- Filename: name of the file without extension 
- Language: language to localize

