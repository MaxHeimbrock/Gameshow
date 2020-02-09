public interface IState
{
    void Enter();
    void Execute();
    void Exit();
}

public class StateMachine
{
    private IState currentState;

    public void NextState(IState nextState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = nextState;
        nextState.Enter();
    }

    public void Update()
    {
        if (currentState != null)
        {
            currentState.Execute();
        }
    }

    public IState GetCurrentState()
    {
        return currentState;
    }
}

