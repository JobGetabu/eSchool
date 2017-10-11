using System.Collections.Generic;

namespace eSchool
{
    public class PassDataEventArgs : System.EventArgs
    {
        // add local member variable to hold the list
        private List<int> fmStore;

        //class ctor
        public PassDataEventArgs(List<int> fmStore)
        {
            this.fmStore = new List<int>();
            this.fmStore = fmStore;
        }

        //properties
        public List<int> pfmStore
        {
            get
            {
                return fmStore;
            }
        }
    }
}