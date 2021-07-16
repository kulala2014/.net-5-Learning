using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CSharpGrammarInfo.SharpSix
{
    class Student:INotifyPropertyChanged
    {
        public string FirstName { get; }
        public string LastName { get; }
        private int? Id;

        public Student(string firstName, string lastName) => 
            (this.FirstName, this.LastName)=(firstName, lastName);


        //自动属性初始化表达式
        public ICollection<double> Grades { get; } = new List<double>();

        //goes to表达式语句
        //public override string ToString()
        //{
        //    return $"{FirstName} - {LastName}";
        //}

        public override string ToString() => $"{FirstName} - {LastName}";

        public string FullName
        {
            get
            {
                return $"{FirstName} - {LastName}";
            }
        }

        public string FullName1  => $"{FirstName} - {LastName}";
        public string TestName { get; set; }
        public int? ID
        { 
            get { return Id; }
            set 
            {
                if (value != Id)
                {
                    this.Id = value;
                    PropertyChanged?.Invoke(this,
                        new PropertyChangedEventArgs(nameof(ID)));
                }
            }
         }
        public event PropertyChangedEventHandler PropertyChanged;


    }
}
