using System;
using System.Collections.Generic;

namespace ToDoList.Domain
{
    public class ToDo
    {
        public int id { get; set; }
        
        public string descricao { get; set; }

        public List<ToDoItem> items { get; set; }

        public ToDo(){
            
        }
    }
}
