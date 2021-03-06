﻿using System;
using System.Collections.Generic;
using System.Text;

namespace xf3031
{
    public class MyTaskRepository
    {
        public List<MyTaskItem> GetMyTask()
        {
            List<MyTaskItem> fooMyTaskItems = new List<MyTaskItem>();

            for (int i = 0; i < 10; i++)
            {
                fooMyTaskItems.Add(new MyTaskItem
                {
                    MyTaskName = $"我的工作名稱 {i}",
                    MyTaskStatus = i % 3 == 0 ? "進行中" : "未開始",
                    MyTaskDate = DateTime.Now.AddDays(i)
                });
            }
            return fooMyTaskItems;
        }
    }
}
