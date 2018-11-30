using System;

namespace ToDoList.Domain
{
    public class ToDo
    {
        public ToDo(){}
        
        public ToDo(int id, string descricao)
        {
            this.id = id;
            this.descricao = descricao;
        }

        public int id { get; set; }
        public string descricao { get; set; }
    }
}
