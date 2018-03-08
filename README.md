# JoystickPanGestureBug
Xamarin Forms Pan Gesture Not firing completed event - test case

Example project created for testing this Xamarin Forms bug: [Android] PanGestureRecognizer occasionally neglects firing the Completed event #1495 https://github.com/xamarin/Xamarin.Forms/issues/1495

Move the joystick to the extents. Releasing it shoud move back to the center. Sometimes it sticks to the outside due to the completed event not firing.
