# UnityUtils
A mix of utils for Unity3D. Some are my own, others are copied and adapted.

I personally use this scripts for my game jam entries.

## How to install
TODO


## List of Utilities by categories

### Camera
* FollowLocalPlayer → A rudimentary way to follow a player in a X side scroller game
* SmoothCamera2D → The smooth way to make the camera follow a transform target
* MirrorFlipCamera → Create the mirror effect on a camera

### Compatibility
* MouseClick → Handle mouse clicks indifferently of the imput system. 
* MousePosition →  Handle mouse the position indifferently of the imput system

> This two mouse scripts should be executed before read the mouse clicks or position to work optimally. 
> Change the order in: Edit > Project Settings > Script Execution Order

### Coroutines
CoroutineUtils → Handful set of coroutines funtions to make them easy to use

### Data
AdvancedStateMachineBehaviour
DataSerializer
Hasher
PlayerPrefsX
Shuffle
ValidationUtils

### Editor
DynamicScale
RegexAttribute
RegexDrawer
SelectionBase

### Extensions
AnimatorExtensions
CollectionUtils
EmumUtils
GameObjectExtensions
IntegerExtensions
RandUtils
RectTransformExtensions
RendererExtensions
UISetExtensions

### Game Flow
LoadScene
OnSceneLoad
QuitApplication

### GameObjectActions
AutoRotate
ChangePointer
GoVector
LightBlink
LookAt
LookAtMouse
MoveToMouse
SinMove

### Game Objects
BasicPooler
DontDestroy
MouseClicks
PlayerSpaw
* Singleton 
    * MonoBehaviourSingleton
    * MonoBehaviourSingletonPersistent

### Integrations
RankClient
GoogleDriveCSVDownloader
#### HTTP
RequestManager
JsonHelper

### Localization
Localization

### Shaders
TO-DO

### Sound
* MusicManager → handle the background music (looped and persistant between scenes)
* SoundManager → play sound effects with a randomized variance

### UI Helpers
* Counter → A simple countdown counter
* FPS → Frame Per Seconds counter. Just add the prefab to your scene
* Menu → Manage Animated menus easily
* AlwaysOnTop → Set the game window always over the top
* BlinkText → Make text component blink
* FadeColor → Fade the color of a sprite component 


## TO DO
* Add camera examples
* Add coroutines examples
* Add editor examples
* Add extensions examples
* Add more UI helper examples
* Add unity extensions examples
* Add Localization examples
* Improve and add integration examples
* Update deprecated methods and add http examples
* Prepare shaders and examples
* Improve Localization and add examples
* Add tests


## Dependencies
* DOTween
* TextMesh Pro

## Authorship
I try to keep the original authorship of the scripts with links to the source as code comments. These links usually lead answers.unity.com. 

If any authorship is not well identified or you don't want your script to be here, let me know.

## Collaborate!
PRs are welcome. 

Please feel free to suggest new scripts or improve the current ones.
