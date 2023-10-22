# RPG 2D Game
 Made using Unity. This is a basic RPG Game. 

Enjoy exploring a 2D world! Use the following keys to navigate:

- ↑ (Up Arrow) to move up
- ↓ (Down Arrow) to move down
- ← (Left Arrow) to move left
- → (Right Arrow) to move right


<div style="display:flex; justify-content:center;">
    <div style="flex:50%; text-align:center; padding-right: 10px;">
        <img src="Pictures/castle.png" alt="World" style="width:100%">
    </div>
    <div style="flex:50%; text-align:center; padding-left: 10px;">
        <img src="Pictures/characterworldenemy.png" alt="World" style="width:100%">
    </div>
</div>



Be careful not to take damage from enemies!

<div style="display:flex; justify-content:center;">
    <div style="flex:50%; text-align:center; padding-right: 10px;">
        <img src="Pictures/hurtplayer.png" alt="World" style="width:100%">
    </div>
    <div style="flex:50%; text-align:center; padding-left: 10px;">
        <img src="Pictures/destroyedplayer.png" alt="World" style="width:100%">
    </div>
</div>


Still a work in progress ATM
## Dev Notes

16/10/23
- Modify the camera transform position after expanding world. Move the camera object to where the world clips and use the coordinates for minPosition(x and y)
and maxPosition(x and y)

17/10/23
- In order to use Prefab drag into scene and set the New Min Position and New Max Position from the position of the camera(X and Y position)


Initial world looked like this. Note no healthbar or enemies:
<div style="text-align:center;">

<img src="image.png" alt="World" width="60%" height="60%">

</div>