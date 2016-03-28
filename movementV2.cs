// 8-directional movement for a playable character

// game loop in the main programme
private void Timer_Tick(object sender, object e)
{
    // temporary variables for initial X and Y directions
    int dirX = 0;
    int dirY = 0;
    
    // calculating initial X and Y directions
    // TODO: if... requirements have to be changed to actuall keypresses
    // this also requires a switch case within the main programme which checks wheter or not a key is down
    // the switch case is located just outside of the game loop
    // (CoreWindow_KeyDown . . .)
    if (APressed) dirX -= 1;
    if (DPressed) dirX += 1;
    if (WPressed) dirY -= 1;
    if (SPressed) dirY += 1;
    
    Player.Move(dirX, dirY);
}

// move method for the player character, contained within the player class
void Move (int dirX, int dirY)
{
    // speed settings; speed and acceleration are defined in class's private fields
    speed += acceleration;
    if (speed > maxSpeed) speed = maxSpeed;
    
    // if X or Y change is 0, there's no need for further calculation
    if (dirX == 0 || dirY == 0)
    {
        LocationX += speed * dirX;
        LocationY += speed * dirY;
    }
    
    // if both X and Y change, the actual amount of movement has to be re-evaluated so that the movement area is not a square but rather a stop-sign
    // this way speed stays the same regardless of the direction of the movement
    else
    {
        // (Math.PI/4) is 45 degrees in radians
        LocationX += Math.Cos(Math.PI/4) * dirX * speed;
        LocationY += Math.Sin(Math.PI/4) * dirY * speed;
    } 
}