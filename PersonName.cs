using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
namespace NameClassify
{
    internal class PersonName
    {
        // Fields
        private string _fullname, _title, _firstName, _lastName;

        // Properties
        public string fullname
        {
            get { return _fullname; }
            set { _fullname = value; }
        }
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string firstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string lastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        // Constructor
        // Overloaded constructor
        public PersonName()
        {
            this.fullname = "";
            this.title = "";
            this.firstName = "";
            this.lastName = "";
        }
        // Overloaded constructor
        public PersonName(string fullname)
        {
            this.fullname = fullname;
            this.title = "";
            this.firstName = "";
            this.lastName = "";
            splitName();
        }


        // Methods
        // Overloaded method
        public void splitName()
        {
            string[] prefix = { "นาย", "นาง", "นางสาว", "เด็กชาย", "เด็กหญิง" };
            this.title = "";
            string nameLeft = "";
            if (fullname.Contains("."))
            {
                // ['ด.ช. เนม สกุล']
                int lastDot = fullname.LastIndexOf('.');
                if (lastDot != -1)
                {
                    this.title = fullname.Substring(0, lastDot + 1);
                    nameLeft = fullname.Substring(lastDot + 1).Trim();
                    int firstSpace = nameLeft.IndexOf(' ');
                    this.firstName = nameLeft.Substring(0, firstSpace);
                    this.lastName = nameLeft.Substring(firstSpace + 1);
                }
            }
            else
            {
                string[] name = fullname.Split(' ');
                if (name[0].Contains(prefix[0]) || name[0].Contains(prefix[1]) || name[0].Contains(prefix[2]) || name[0].Contains(prefix[3]) || name[0].Contains(prefix[4]))
                {
                    this.title = name[0];
                    this.firstName = name[1];
                    for (int i = 2; i < name.Length; i++)
                    {
                        this.lastName += $"{name[i]} ";
                    }
                    return;
                }
                this.firstName = name[0];
                for (int i = 1; i < name.Length; i++)
                {
                    this.lastName += $"{name[i]} ";
                }
            }
        }

        // Overloaded method
        public void splitName(string fullname)
        {
            string[] prefix = { "นาย", "นาง", "นางสาว", "เด็กชาย", "เด็กหญิง" };
            this.title = "";
            string nameLeft = "";
            if (fullname.Contains("."))
            {
                // ['ด.ช. เนม สกุล']
                int lastDot = fullname.LastIndexOf('.');
                if (lastDot != -1)
                {
                    this.title = fullname.Substring(0, lastDot + 1);
                    nameLeft = fullname.Substring(lastDot + 1).Trim();
                    int firstSpace = -1;
                    if (nameLeft.IndexOf(' ') != -1)
                    {
                        firstSpace = nameLeft.IndexOf(' ');
                        this.firstName = nameLeft.Substring(0, firstSpace);
                        this.lastName = nameLeft.Substring(firstSpace + 1);
                        return;
                    }
                    this.firstName = nameLeft;
                    this.lastName = "";

                }
            }
            else
            {
                int lengthOfPrefix = 0;
                string[] name = fullname.Split(' ');
                if (name[0].Contains(prefix[0]) || name[0].Contains(prefix[1]) || name[0].Contains(prefix[2]) || name[0].Contains(prefix[3]) || name[0].Contains(prefix[4]))
                {
                    for (int i = 0; i < prefix.Length; i++)
                    {
                        if (name[0].Contains(prefix[i]))
                        {
                            this.title = prefix[i];
                            lengthOfPrefix = prefix[i].Length;
                            break;
                        }
                    }
                    this.firstName = name[0].Substring(lengthOfPrefix);
                    for (int i = 1; i < name.Length; i++)
                    {
                        this.lastName += $"{name[i]} ";
                    }
                    return;
                }
                this.firstName = name[0];
                for (int i = 1; i < name.Length; i++)
                {
                    this.lastName += $"{name[i]} ";
                }
            }
        }
    }
}