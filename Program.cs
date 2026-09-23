CoolingSystem currentCoolingSystem = new CoolingSystem();
DiagnosticSession diagnosticSession = new DiagnosticSession(currentCoolingSystem);

currentCoolingSystem.StartFault(ErrorReason.ExhaustBlocked);

diagnosticSession.DisplayDiagnostics();

RepairOption choice = diagnosticSession.GetRepairChoice();

diagnosticSession.ExecuteRepair(choice);

diagnosticSession.DisplayDiagnostics();


public class DiagnosticSession
{
    private CoolingSystem currentCoolingSystem;

    public DiagnosticSession(CoolingSystem currentCoolingSystem)
    {
        this.currentCoolingSystem = currentCoolingSystem;
    }

    public void DisplayDiagnostics()
    {
        Console.WriteLine($"Current status: {currentCoolingSystem.GetStatus()}");
        Console.WriteLine($"Current error reason: {currentCoolingSystem.GetErrorReason()}");
    }

    public RepairOption GetRepairChoice()
    {
        while(true)
        {
            Console.Write("Select a repair option (1-3): ");
            string input = Console.ReadLine().Trim();

            if(int.TryParse(input, out int inputConverted) && inputConverted >= 1 && inputConverted <= 3)
            {
                RepairOption repairOption = inputConverted switch
                {
                    1 => RepairOption.RestartPump,
                    2 => RepairOption.ClearExhaust,
                    3 => RepairOption.IncreasePressure,
                    _ => RepairOption.RestartPump
                };

                return repairOption;
            }
        }
    }

    public void ExecuteRepair(RepairOption repair)
    {
        bool repaired = currentCoolingSystem.AttemptRepair(repair);

        if (repaired)
        {
            Console.WriteLine("Repair successful.");
        }
        else
        {
            Console.WriteLine("Repair failed.");
        }
    }
}

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