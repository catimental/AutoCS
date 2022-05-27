using System;
using System.Windows.Forms;

namespace AutoCS.Client.Script.Conversations
{
    public class Keyboard
    {
        private Profile.Profile _profile;
        public Keyboard(Profile.Profile profile)
        {
            _profile = profile;
        }

        public void KeyPress(char c)
        {
            //throw new NotImplementedException();
            //_profile.GetInternalProcess().KeyPress(c);
            _profile.GetInternalProcess().KeyPress(c);
        }
    }
}