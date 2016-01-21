#AudioManager

This script is derived from the [Brackeys](http://brackeys.com/) tutorial. This is a centralised script which will play a sound from a given list of sound, based on the name which is given by the user from another script

###How to Use

For a detailed explanation of the working of the script, do check out [this tutorial by Brackeys](https://www.youtube.com/watch?v=HhFKtiRd0qI) explaining the working of the script

For a quick note on making the audio play from another script - 
* Create an instance of the ```AudioManager``` on the script from which we need to call the ```AudioManager.cs ```  script, For ex, 

``` private AudioManager audioManager;```

* Set the instance in the  ```Start()``` method ( or the ``` Awake() ``` method)

```audioManager= AudioManager.instance;```

* Call the ```PlaySound()``` function from wherever we need to play the sound of the name ```<Name>```
```audioManager.PlaySound("<Name>")```
