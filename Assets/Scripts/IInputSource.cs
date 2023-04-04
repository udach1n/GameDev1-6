public interface IInputSource
{
    float HorizontalMoving { get; }

    bool Jump { get; }

    void ResetActions();

}
