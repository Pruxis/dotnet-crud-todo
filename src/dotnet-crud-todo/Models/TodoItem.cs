using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_crud_todo.Models {
    public class TodoItem {
        public string Key { get; set; }
        public string Name { get; set; }
        public bool isComplete { get; set; }

    }
}
