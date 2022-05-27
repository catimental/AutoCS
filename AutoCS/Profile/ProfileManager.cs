using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCS.Client.Profile
{
    public sealed class ProfileManager
    {
        private List<Profile> profileList;
        private static readonly Lazy<ProfileManager> _instance = new Lazy<ProfileManager>(() => new ProfileManager()); // lazyEvalution Singleton

        private ProfileManager()//private Constructor
        {
            profileList = Profile.ImportAll();
        } 

        public static ProfileManager Instance
        {
            get { return _instance.Value; }
        }

        public List<Profile> GetProfileList()
        {
            return this.profileList;
        }

        public void AddProfile(Profile profile)
        {
            profileList.Add(profile);
        } 
    }
}
