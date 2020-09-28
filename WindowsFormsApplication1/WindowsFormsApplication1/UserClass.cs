using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class UserClass
    {
        public int id;
      //  private string name;
        public string userName;
      //  private string password;
      //  private int type;

        public void setId(int id) { 
            this.id = id; 
        }
      //  public void setName(string name) { this.name = name; }
        public void setUserName(string userName) { this.userName = userName; }
       // public void setPassword(string password) { this.password = password; }
       // public void setType(int type) { this.type = type; }

        public int getId() { return id; }
//        public string getName() { return name; }
        public string getUserName() { return userName; }
  //      public string getPassword() { return password; }
    //    public int getType() { return type; }
    }
}
