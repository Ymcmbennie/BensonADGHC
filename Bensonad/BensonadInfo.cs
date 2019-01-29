using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace Bensonad
{
    public class BensonadInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "Bensonad";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return Properties.Resources.AverageIcon;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "This is a private plugin develop to automate most of my personal day to day grasshopper tasks";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("602d2e08-9252-419b-9004-478390bb50b3");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "Benson Eusebio Sanga";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "Bensonsanga@hotmail.com";
            }
        }
    }
}
