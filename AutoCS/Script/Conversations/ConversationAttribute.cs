namespace AutoCS.Client.Script.Conversations
{
    public class ConversationAttribute:System.Attribute
    {
        private string _scopeName;
        public ConversationAttribute(string scopeName)
        {
            _scopeName = scopeName;
        }

        public string ScopeName
        {
            get { return _scopeName; }
        }
    }
}