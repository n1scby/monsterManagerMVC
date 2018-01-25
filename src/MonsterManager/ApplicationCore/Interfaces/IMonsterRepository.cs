using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IMonsterRepository
    {
        List<Monster> GetMonsterList();
        Monster GetMonsterByID(int id);
        void Add(Monster newMonster);
        void Edit(Monster updatedMonster);
        void Delete(Monster deleteMonster);
    }
}
