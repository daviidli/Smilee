# Smilee
###### *GIVE US YOUR BEST SMILEE*

![image](https://github.com/daviidli/daviidli.github.io/blob/master/images/smilee.png)

## Description:
This is a project created for NWHacks 2017 in Vancouver. We wanted to use the hackathon to learn more about using Unity and also some of Microsoft's Cognitive Services APIs. Smilee is a endless sidescroller that has a bunny hopping over carrots to avoid dying. Along the way, when you reach certain scores, the game will prompt a camera to appear and take a picture of your face. Based on the facial expression, the game will use Microsoft's Emotion API to retrieve the most prominent emotion. Depending on which emotion is detected, your in game character will get a special ability.

## How it was built:
We created this game mainly in Unity (2D) using C# as the scripting language. The graphics were made on [Piskel](http://www.piskelapp.com/) and exported as PNG's.

## Challenges we ran into:
When making Smilee, two of our hardest problems were the implementation for communicating with the API and the implementation of the camera.
This being the first time we used Unity, C# and Microsoft's API, we spent a considerable amount of time trying to figure how to send it the right image, and receive the JSON data to parse.
Unity does not have a built in native camera class, and we had to figure a way around that. Doing some reseach, we found that Unity has the `WebCamTexture` class, which we used to place a live feed of the camera onto a game object as a texture then saving that texture as an image.

