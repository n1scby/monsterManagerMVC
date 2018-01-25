using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Infrastructure
{
    public class MonsterRepositoryFS : IMonsterRepository
    {
        private static List<Monster> _monsterList;
        private static int _nextNum = 1;

        private const string PATH = "data";
        private const string FILENAME = "monsterData.json";

        private readonly string _fileFullPath = Path.Combine(PATH, FILENAME);

        public MonsterRepositoryFS()
        {


            if (_monsterList == null)
            {
                _monsterList = LoadFile();

                if (_monsterList.Count > 0)
                {
                    _nextNum = _monsterList.Max(m => m.Id) + 1;
                }

            }

        }

        public List<Monster> GetMonsterList()
        {
            return _monsterList;
        }
        public Monster GetMonsterByID(int id)
        {
            return _monsterList.Find(m => m.Id == id);

        }

        public void Add(Monster newMonster)
        {
            newMonster.Id = _nextNum++;
            _monsterList.Add(newMonster);
            SaveFile();
        }

        public void Edit(Monster updateMonster)
        {
            Monster origMonster = GetMonsterByID(updateMonster.Id);
            origMonster.Name = updateMonster.Name;
            origMonster.Color = updateMonster.Color;
            origMonster.NumberOfEyes = updateMonster.NumberOfEyes;
            origMonster.NumberOfArms = updateMonster.NumberOfArms;
            origMonster.Image = updateMonster.Image;
            SaveFile();

        }

        public void Delete(Monster deleteMonster)
        {
            Monster removeMonster = GetMonsterByID(deleteMonster.Id);
            _monsterList.Remove(removeMonster);
            SaveFile();
        }

        public List<Monster> LoadFile()
        {
            try
            {
                string rawListStr = File.ReadAllText(_fileFullPath);

                List<Monster> rawList = JsonConvert.DeserializeObject<List<Monster>>(rawListStr);

                return rawList;
            }
            catch (Exception ex)
            {
                // TODO Log the exception

                return new List<Monster>();
            }
        }


        public void SaveFile()
        {
            try
            {
                if (!Directory.Exists(PATH))
                {
                    Directory.CreateDirectory(PATH);
                }

                string rawListStr = JsonConvert.SerializeObject(_monsterList);

                File.WriteAllText(_fileFullPath, rawListStr);
            }
            catch (Exception ex)
            {
                // TODO Log the exception
            }
        }

    }
}
