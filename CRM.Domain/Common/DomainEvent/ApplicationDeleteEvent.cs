using CRM.Domain.Common;


namespace CRM.Domain.Common.DomainEvent;

public record ApplicationDeleteEvent(int id):IDomainEvent;