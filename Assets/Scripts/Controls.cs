namespace Heal.Components
{
    public static class Controls
    {
        private static MainControls _inputActions;

        public static MainControls InputActions
        {
            get
            {
                if (_inputActions == null)
                {
                    _inputActions = new MainControls();
                    _inputActions.Enable();
                    return _inputActions;
                }
                else return _inputActions;
            }
        }
    } 
}