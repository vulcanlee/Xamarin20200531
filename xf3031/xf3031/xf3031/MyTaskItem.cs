using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace xf3031
{
    public class MyTaskItem : INotifyPropertyChanged,ICloneable 
    {

        public event PropertyChangedEventHandler PropertyChanged;
        //工作名稱
        public string MyTaskName { get; set; }
        //狀態
        public string MyTaskStatus { get; set; }
        //指派日期
        public DateTime MyTaskDate { get; set; }


        public MyTaskItem Clone()
        {
            ICloneable cloneable = this;
            MyTaskItem result = cloneable.Clone() as MyTaskItem;
            return result;
        }

        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
