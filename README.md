# Projectile Motion - Unity3D

- A project to implement the concept of Projectile-Motion and the physics properties required to achieve the desired motion of a projectile.

- More specifically, this project deals with the calculation of the angle required to launch a projectile such that it hits the desired target, in this case the player which is a tank.

### Angle *θ* required to hit coordinate *(x, y)*: <br />
To hit a target at range ***x*** and altitude ***y*** when fired from *(0, 0)* and with initial speed v the required angle(s) of launch *θ* are: <br /><br />
![Projectile_Equation](https://user-images.githubusercontent.com/67199656/179363518-8e66f612-e133-4521-8b32-0221803c3e84.png) <br /><br />
The two roots of the equation correspond to the two possible launch angles, so long as they aren't imaginary. <br />
If the roots happen to be imaginary, the initial speed is not great enough to reach the point *(x, y)* selected.  <br /><br />
This formula allows one to find the angle of launch needed without the restriction of *y = 0*. <br /><br />


![Gameplay Screenshot](https://user-images.githubusercontent.com/67199656/179364216-aac041dc-dc9a-45e3-ade3-5938a281f1a5.png)



