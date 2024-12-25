using MassTransit;

namespace CRMAPI.Application.Dtos;

public class Message
{
    public Guid Id { get; set; }
    public string Content { get; set; }
}