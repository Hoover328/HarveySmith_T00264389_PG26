\# Moveset Test  

\*Valid as of 19/01/26\*



\## Controls



The key controls and functions that I want in the player's moveset are:



\- \*\*W\*\* – Move the player forward \*(DONE)\*

\- \*\*A\*\* – Strafe left \*(DONE)\*

\- \*\*S\*\* – Strafe right \*(DONE)\*

\- \*\*D\*\* – Move the player backwards \*(DONE)\*

\- \*\*Space\*\* – Make the player jump \*(POSSIBLE ERRORS, FIXING)\*

\- \*\*Shift\*\* – Make the player dash \*(DONE)\*

\- \*\*Mouse\*\* – Move the first-person camera \*(DONE)\*

\- \*\*Left Mouse Button\*\* – Melee attack \*(NEEDS POLISH)\*



The overall movement is almost fully complete. The only current issue I am facing is with the jumping. Sometimes the jumping does not act the same as it normally does and prevents high levels of movement that I want.



In terms of the overall moveset, the attacking is working well enough, but I have run into a number of issues related to this and may run into more in the future as I continue to add more to my game.



---



\## Current Position



I have a majority of the player's moveset working as intended, so my current focus is on the player's UI and how the player interacts with enemies or other objects in the environment.



In terms of UI, I currently have a \*\*dash bar\*\* that progressively fills up from 0 to 100. Once reaching 100, the player can dash again. This works as a visual indicator for the dash cooldown, which is necessary for good gameplay.



I have also included a \*\*sword\*\* in the UI, which will be the player's weapon but will also act as a visual indicator for the attack cooldown, similar to the dash bar.



I next plan to include a \*\*health bar\*\*, which will work as expected.



\### UI Elements Status

\- Dash Bar \*(NEEDS POLISH)\*

\- Player Weapon \*(NOT DONE)\*

\- Health Bar \*(NOT DONE)\*



---



\## Testing Scene



All testing for the moveset is located in the \*\*“Movement Test”\*\* scene, as shown below.



!\[Movement Test Scene](images/WhereToFind.png)



The only issues I am currently running into involve how my UI elements do not fit the size of the screen correctly when moving from full screen to a smaller window.



I developed the UI on a small screen, but now when running in fullscreen the dash bar is too small and does not reach all the way up the screen. This is something I plan to fix soon.



!\[Movement Test Scene](images/TestIssues.png)



---



\## Movement Demonstration



The movement in this test is demonstrated with two jumps:



\- One jump can be made easily with a standard jump

\- The other jump can only be made by using a dash followed by a jump



Currently, the dash itself is not visible. This is something I plan to add later (such as a visual indication of dashing, wind effects on the screen, etc.).



At the moment, the jump is only made when dashing, which demonstrates the mechanic.



The test dummies can be attacked using the sword. When hit, they flash red to indicate a successful hit. The dummies will also always face the player to create a \*\*2.5D\*\* look for the game.



I plan to keep this visual theme throughout the project.



---



\## Artwork / Sprites



All artwork used in this project—including swords, enemies, dummies, and future sprites—is created by my girlfriend and is not taken from online sources or asset stores.



These sprites are designed to reinforce the \*\*2.5D aesthetic\*\* of the game.



The sprites used so far are shown below:



!\[Movement Test Scene](images/Weapons.jpg)

!\[Movement Test Scene](images/Dummy.png)



