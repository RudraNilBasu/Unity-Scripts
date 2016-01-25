#CameraShake

Performing a camera shake effect. The code was derived from [Brackeys Tutorials](https://www.youtube.com/user/Brackeys). 

##How to use
For detailed explanation of the codes, watch [this tutorial by Brackeys](https://www.youtube.com/watch?v=Y8nOgEpnnXo&index=22&list=PLPV2KyIb3jR42oVBU6K2DIL6Y22Ry9J1c).

* ```mainCam``` is the camera GameObject which is to be shaked.
* Attach the script on any Game Object. Call the ```Shake(float amt, float length)``` function from any external script passing the ``` amt``` and ```length``` (refering to the amount of shake and the length of the shake respectively) as arguments.
* NOTE : If you are using it in a 2D Game, and using an orthographic camera, then remove the following lines from the code : 
  - Line 32  ```float offsetZ = Random.value * shakeAmount * 2 - shakeAmount; ```
  - Line 36 ```mainCamPos.z += offsetZ;```
