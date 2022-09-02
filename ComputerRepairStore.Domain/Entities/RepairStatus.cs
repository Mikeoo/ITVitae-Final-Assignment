namespace ComputerRepairStore.Domain.Entities
{
    public enum RepairStatus
    {
        Received,
        WaitingForParts,
        InProcess,
        Finished,
        Cancelled
    }
}
