# GamesLab
Coursework for 'Games Design & Development' course, the purpose of this exercise it to test various capabilities of the games engine such as Physics, transformations and ray-tracing. Visual Studio 2017 was also used as the IDE for scripting in C#.

Here is the script files used in the game, the largest portion of programming was done for the last exercise which was a 2D platformer. I do not own any of the assets in the game, however have made sure that they are royalty free. If you are interested in downloading the game folder it can be found here: https://drive.google.com/open?id=1EFbBzeUXJj1WC_jSmZZptT4bLfu__BXV

Working as of [17/05/2019]

# Content
[Exercise 1] - Rube Goldberg machine. For anyone that doesn't know, a rube goldberg machine is a machine that is designed to perform a particular task such as put a teabag into your cup of tea, but it is done so in a spectacular and often overcomplicated fashion! In this exercise a single sphere takes full advantage of the engines physics to move the components as they collide with eachother, creating a seamless 'Goldberg machine'.

[Exercise 2] - Island. In this exercise I worked with Unity 5's terrain creation tool which allows you to edit the environment with trees and shrubs. I also made use of lighting techniques and particle systems to add an ambiance to the scene, ending up with a sort of apocolyptic feel to the scene.

[Exercise 3] - Clock Exercise. In this exercise a clock makes use of the update script to perform a full cycle every minute, this correlates with a moving camera that follows the clock forward and a transformation on the directional light. This produces the effect that the time of day is changing in sync with the clocks time.

[Exercise 4] - Traffic Light. In this exercise we needed to create a traffic light using C# techniques we had learned previously, along with a pseduo-diagram which made it easier to imagine how a traffic light operates. In my case I used multiple if statements that changed the materials on the lights depending on multiple variables, the timer would reset when the button was pressed and count down from '15' this would allow the traffic-light cycle through its colours and then return to green. It was an interested exercise that showed how useful deltaTime is in performing such operations.

[Exercise 5] - The 2D Platformer. This platformer was created by making use of various C# techniques such as changeing the direction of the character, depending on the movement direction and collisions to kill the enemies and incorporate pickups.

[Main Menu] - This was created using the Unity UI elements, it uses the sceneManager to change between scenes and is available in every level.
