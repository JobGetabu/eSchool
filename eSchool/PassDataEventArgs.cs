using System.Collections.Generic;

namespace eSchool
{
    public class PassDataEventArgs : System.EventArgs
    {
        // add local member variable to hold the list
        private List<int> fmStore;
        private int tmStore;
        private int yrStore;
        //class ctor
        public PassDataEventArgs(List<int> fmStore,int tmStore, int yrStore)
        {
           
            this.fmStore = fmStore;
            this.tmStore = tmStore;
            this.yrStore = yrStore;
        }

        //properties
        public List<int> pfmStore
        {
            get
            {
                return fmStore;
            }
        }

        public int ptmStore
        {
            get
            {
                return tmStore;
            }
        }

        public int pyrStore
        {
            get
            {
                return yrStore;
            }
        }
    }
}