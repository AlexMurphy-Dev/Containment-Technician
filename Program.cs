CoolingSystem coolingSystemA = new CoolingSystem();

Console.WriteLine(coolingSystemA.GetStatus());

coolingSystemA.StartFault(ErrorReason.ExhaustBlocked);
Console.WriteLine(coolingSystemA.GetStatus());

bool repaired = coolingSystemA.AttemptRepair(RepairOption.RestartPump);
Console.WriteLine(coolingSystemA.GetStatus());
Console.WriteLine(repaired);

repaired = coolingSystemA.AttemptRepair(RepairOption.ClearExhaust);
Console.WriteLine(coolingSystemA.GetStatus());
Console.WriteLine(repaired);


public class CoolingSystem
{
    private ErrorReason errorReason;
    private Status status;

    public Status GetStatus() => status;
    public ErrorReason GetErrorReason() => errorReason;
    public void StartFault(ErrorReason errorReason)
    {
        switch (errorReason)
        {
            case ErrorReason.ExhaustBlocked:
                status = Status.Faulted;
                this.errorReason = errorReason;
                break;
        }
    }

    public bool AttemptRepair(RepairOption repair)
    {
        if (errorReason == ErrorReason.ExhaustBlocked && repair == RepairOption.ClearExhaust)
        {
            status = Status.Working;
            errorReason = ErrorReason.None;
            return true;
        }

        return false;
    }
}

public enum ErrorReason
{
    None,
    ExhaustBlocked

}

public enum Status
{
    Working,
    Faulted
}

public enum RepairOption
{
    RestartPump,
    ClearExhaust,
    IncreasePressure
}