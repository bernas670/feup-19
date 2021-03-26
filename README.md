<div style="text-align:center;"><img src="https://i.imgur.com/6XBsYmn.png" width="400"></div>
<div style="display: flex; flex-direction: column; align-items: flex-end;">
<div>by <a href="https://github.com/bernas670">Bernardo Santos</a> and <a href="https://github.com/CajoAlbuquerque">Carlos Albuquerque</a></div>
<div>for DJCO 20/21</div>
</div>

## Summary
**feup-19** is an endless runner set in FEUP's B hallway. You are a student and your goal is to try and make it as far as you can! Avoid the roaming virus and dodge the infected professor Augusto Sousa's slime.

## Installing
There is no need for instalation, we provide zip files with the executable for the game. Simply access [this link](https://drive.google.com/drive/folders/1f_kVvynAwAfD-V1LWVL8-pdZPPixoEnM?usp=sharing) and download the correct version for your system. Afterwards, unpack the archive and run the executable. Last, but not least, **have fun**!

## Controls
The controls are very simple:
 - ![](https://i.imgur.com/i0fRMbA.png) or ![](https://i.imgur.com/mhJWnCL.png) to **jump**
 - ![](https://i.imgur.com/vtOi6vR.png) or ![](https://i.imgur.com/LE0iHCA.png) to **slide**
 - ![](https://i.imgur.com/2jmiX55.png) to **shoot**
 - **Escape** to **pause**

## Game Info
You are a student at FEUP trying to make your way through the B building, which has been overtaken by <i>Infected</i> professors and <i>Viruses</i>, you must fight them off in order to survive as long as possible. At your disposal you have one of those hand sanitizers that sprays everywhere. During your journey you may pick up some power-ups like: masks, fire rate multipliers and vaccines.

This is a fast paced, side-scrolling, endless runner, shooter type of game, with focus on coordination. The player needs to avoid obstacles (the roaming viruses) by jumping or sliding, dodge enemy projectiles, neutralize enemies, gather power-ups and make a path through the mayhem that is the B corridor, all of this simultaneously.

### Player Base Mechanics
#### Movement
The player is constantly running and, in order to dodge enemy projectiles and obstacles or catch the power-ups, is able to jump and slide.

#### Shooting
To make the game simpler we decided to give the player infinite ammo, but to balance it out he has a fixed fire rate.
The player has two types of ammo available:
<div style="display: flex; flex-direction: row; flex-wrap: wrap; justify-content: space-around;">   
    <div style="display: flex; flex-direction: row; align-items: center;">
        <img style="margin-right: 20px;" src="https://i.imgur.com/WO8C1G2.png" width="100" height="100">   
        <div>
            <h4>Sanitizer</h4>
            <p>Regular ammo</p>
        </div>
    </div>
    <div style="display: flex; flex-direction: row; align-items: center;">
        <img style="margin-right: 20px;" src="https://i.imgur.com/7TFAMNb.png" width="100" height="100">   
        <div>
            <h4>Vaccine</h4>
            <p>Available from the <i>Vaccine</i> power-up</p>
        </div>
    </div>
</div>

#### Health
The player has three health points and there is no way to regenerate health.
Upon losing health the player becomes invincible for 2 seconds.

### Enemies and Obstacles
<div>
    <div style="display: flex; flex-direction: row;">
        <img src="https://i.imgur.com/RDpMAHF.png" width="300">
        <div>
            <h4>Infected</h4>
            <p>Spotted all over the B hallway, <i>Infected</i> aren't very friendly and spit some kind of green slime at you. They look like a professor... One with a big mustache...</p>
            <p>This enemy can be neutralized with either sanitizer (regular ammo) or vaccines (obtained through the <i>Vaccine</i> power-up).</p>
        </div>
    </div>
    <div>
        <div>
            <h4>Virus</h4>
            <p>Unlike the <i>Infected</i>, <i>Virus</i> do not stand still, making them a challenge for the player's attention and dexterity. In order to destroy these obstacles the <i>Vaccine</i> power-up must be active, since the regular sanitizer the player shoots is not effective against them.</p>
            <p>In order to challenge the player even further we decided to add three different strains, which can be identified by their unique colors. Each strain has a different movement path.</p>
        </div>
        <div style="display: flex; flex-direction: row; flex-wrap: wrap; justify-content: space-around;">   
            <div style="display: flex; flex-direction: row; align-items: center;">
                <img style="margin-right: 20px;" src="https://i.imgur.com/vY3pP75.png" width="100" height="100">   
                <div>
                    <h4>Horizontal Virus</h4>
                    <p>Moves from side to side</p>
                </div>
            </div>
            <div style="display: flex; flex-direction: row; align-items: center;">
                <img style="margin-right: 20px;" src="https://i.imgur.com/5880X4I.png" width="100" height="100">        
                <div>
                    <h4>Vertical Virus</h4>
                    <p>Moves up and down<p>
                </div>
            </div>
        <div style="display: flex; flex-direction: row; align-items: center;">
            <img style="margin-right: 20px;" src="https://i.imgur.com/37n1VWB.png" width="100" height="100">
            <div>
                <h4>Circular Virus</h4>
                <p>Moves in a circle, usually arround power-ups.
            </div>
        </div>
    </div>
</div>

### Power-ups
<div>
    <div style="display: flex; flex-direction: row;">
        <img src="https://i.imgur.com/yXRfAV8.png" width="200" height="200">
        <div>
            <h4>Mask</h4>
            <p>In games like ours, health is a very precious resource, so in order to give the player a little breathing room we created this power-up.</p>
            <p>Masks act like an extra life, allowing the player to take a hit without losing health, which there is no way to regenerate.</p>
            <p>The player can only have a maximum of two masks active.</p>
        </div>
    </div>
    <div style="display: flex; flex-direction: row;">
        <img src="https://i.imgur.com/qVnZo46.png" width="200" height="200">
        <div>
            <h4>2x Pew-Pew</h4>
            <p>Because we are really nice guys we decided to create a power-up that lets the player shoot twice as fast, but to balance it out it only lasts for 10 seconds.</p>
            <p>This power-up is stackable so, for example, if the player catches two of them the fire rate would increase 4 times.</p>
        </div>
    </div>
    <div style="display: flex; flex-direction: row;">
        <img src="https://i.imgur.com/qqzzsMj.png" width="200" height="200">
        <div>
            <h4>Vaccine</h4>
            <p>We are all really tired of Covid, so we give the player the chance to destroy some strains of the virus through this power-up. Not only does it feel great to destroy Coronavirus, but it also rewards the player with some extra points.</p>
            <p>The vaccines only last for 8 seconds so the player must make his shots count! If the player has the power up active, a new pick up will refresh the duration.</p>
        </div>
    </div>
</div>

### Scoring System
To make the game more fun and encourage the player to better himself we implemented the following point system.
| Action                            | Points |
|:----------------------------------|:------:|
| Just being alive                  | 10/sec |
| Destroying an Infected projectile | 10     |
| Neutralizing an Infected          | 100    |
| Neutralizing a Virus              | 200    |

## Credits
### Assets
Most of the assets were actually done by us, the only external ones used were:
 - Player Character - [PandemicWalker](https://pixeldeer.itch.io/pandemicwalker) by [PixelDeer](https://pixeldeer.itch.io/)
 - UI Font - [Press Start 2P](https://www.fontspace.com/press-start-2p-font-f11591) by [CodeMan38](https://www.fontspace.com/codeman38)
 - Music by **Goofy** find him on [YouTube](https://www.youtube.com/channel/UCKJjcs0SNH2EbGN1rVPlHcQ) or [SoundCloud](https://soundcloud.com/user-405330866/tracks)

### Development Process
We had a lot of fun developing this game and we are very happy with the final result. The game might not the be the most complex in the world, but we implemented everything we wanted and ended up with a good and polished game that is enjoyable to play (at least according to our friends). We are also very pleased to see others playing our game, it is an amazing experience to provide good times to strangers and friends alike. 

During development we faced some challenges. We had to learn Unity from scratch, since neither of us had much experience using it, which obviously took some time. When we finally started implementing mechanics and movement, the code started growing a lot and very fast. We had trouble to organize ourselves and make the code readable, so we split the assets in folders and even implemented a State pattern to better organize the PlayerMovement states. At the end of the day we were always thrilled to add more things to the game, despite how more difficult things were getting.

We really hope you like Feup-19, it was made with sweat, blood and tears! But with even more love <3

### Group Members
- Bernardo Santos, up201706534@fe.up.pt
- Carlos Albuquerque, up201706735@fe.up.pt
