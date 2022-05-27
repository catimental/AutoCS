using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCS.Client.Script
{
    public class Script
    {
        private readonly string _name; //파일 이름 = 스크립트 이름으로 할 것
        private readonly string _path;
        public string Path
        {
            get { return _path; }
        }

        public string Name
        {
            get { return _name; }
        }
        
        public Script(string name, string path)
        {
            _name = name;
            _path = path;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object Script)
        {
            return Name.Equals(Script.ToString());
        }
    }
}
