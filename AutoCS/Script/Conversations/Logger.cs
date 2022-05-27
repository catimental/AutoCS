namespace AutoCS.Client.Script.Conversations
{
    public class Logger
    {
        private Profile.Profile _profile;
        public Logger(Profile.Profile profile)
        {
            _profile = profile;
        }

        public void InternalWrite(string log)
        {
            _profile.WriteLog(log);
        }
    }
}