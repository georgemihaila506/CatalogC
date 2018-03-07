using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace UIComand
{
    
    class MenuCommand : Command
    {
        private String menu_name;
        private Dictionary<String, Command> map = new Dictionary<string, Command>();
        public MenuCommand(String command)
        {
            this.menu_name = command;
        }
        public void execute()
        {
            List<String> lista =new List<String>(map.Keys);
            lista.ForEach(x => Console.WriteLine(x));
        }
        public void addCommand(String desc, Command command)
        {
            this.map.Add(desc, command);
        }
        public List<Command> getCommand()
        {
            return this.map.Values.ToList();
        }
        public String getMenuName()
        { return menu_name; }
    }
}
