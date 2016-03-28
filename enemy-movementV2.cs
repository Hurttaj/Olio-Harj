// this is a method for enemy movement
public void Move()
{
    // speed settings
    speed += acceleration;
    if (speed > maxSpeed) speed = maxSpeed;

    // temporary variables for initial X and Y changes and for player location
    double deltaX = 0;
    double deltaY = 0;
    dirX = player.LocationX;
    dirY = player.LocationY;
    
    // calculating the difference between player and enemy coordinates
    deltaX = dirX - LocationX;
    deltaY = dirY - LocationY;

    // calculating the angle between the player and the enemy in degrees
    double Angle = Math.Atan(deltaY / deltaX) * 180 / Math.PI;

    // actual X and Y coordinate calculations
    // sign returns 1 if given number is positive, and -1 if it's negative
    if (deltaX == 0 && deltaY != 0)
    {
       LocationY += speed * Math.Sign(deltaY);
    }

    else if (deltaX != 0 && deltaY == 0)
    {
       LocationY += speed * Math.Sign(deltaX);
    }
    
    else if (deltaX != 0 && deltaY != 0)
    {
       LocationX += (Math.Cos(Math.PI / 180 * (Angle + 90))) * speed * Math.Sign(deltaX);
       LocationY += (Math.Sin(Math.PI / 180 * (Angle + 90))) * speed * Math.Sign(deltaY);
    }
}