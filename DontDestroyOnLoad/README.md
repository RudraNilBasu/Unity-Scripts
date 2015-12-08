#Don't Destroy On Load

The script allows the gameobject (on which the script is present) to stay in the scene when a new scene is loaded (or if the current scene is reloaded).

It also checks if the same GameObject is already present in the current scene or not. If present, it Destroys the current GameObject.

###Application

This is mainly used in GameObjects which stores the music of the game which should keep on playing even if a new scene is loaded.

###How to use

Simply add the script on the GameObject which you want to stay whenever a new scene is loaded.

