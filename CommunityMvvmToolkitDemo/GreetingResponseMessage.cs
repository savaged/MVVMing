using CommunityToolkit.Mvvm.Messaging.Messages;

namespace CommunityMvvmToolkitDemo;

public class GreetingResponseMessage : ValueChangedMessage<string>
{
    public GreetingResponseMessage(string value) : base(value) { }

}
