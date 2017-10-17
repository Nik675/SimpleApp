using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp.Interfaces
{
    public interface IIdeaDatabase
    {
        List<Idea> GetAll();
        Idea Get(int id);
        void Delete(int id);
        void Add(String title, String description);
    }
}
