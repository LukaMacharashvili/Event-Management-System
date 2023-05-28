using EventMaster.Application.Common.Interfaces.Services;

namespace EventMaster.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}