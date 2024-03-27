public class CooldownTimer
{
    #region Public Methods

    public bool IsRunning()
    {
        return _remainingTicks > 0;
    }


    public void Start(int turns)
    {
        _remainingTicks = turns;
    }

    public void Tick()
    {
        _remainingTicks--;
    }

    #endregion Public Methods

    #region Private Variables

    private int _remainingTicks;

    #endregion Private Variables
}