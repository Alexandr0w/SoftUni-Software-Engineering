using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raiding.Factories;
using Raiding.IO.Interfaces;
using Raiding.Models;

namespace Raiding.Core
{
    public class Engine
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;
        private readonly HeroFactory _heroFactory;

        private readonly ICollection<BaseHero> _heroes;

        public Engine(IReader reader, IWriter writer, HeroFactory heroFactory)
        {
            this._reader = reader;
            this._writer = writer;
            this._heroFactory = heroFactory;

            _heroes = new List<BaseHero>();
        }

        public void Run()
        {
            int count = int.Parse(_reader.ReadLine());

            while (count > 0)
            {
                string name = _reader.ReadLine();
                string type = _reader.ReadLine();

                try
                {
                    _heroes.Add(_heroFactory.Create(type, name));
                    count--;
                }
                catch (ArgumentException ex)
                {
                    _writer.WriteLine(ex.Message);
                }
            }

            foreach (var hero in _heroes)
            {
                _writer.WriteLine(hero.CastAbility());
            }

            int bossPower = int.Parse(_reader.ReadLine());

            if (_heroes.Sum(h => h.Power) >= bossPower)
            {
                _writer.WriteLine("Victory!");
            }
            else
            {
                _writer.WriteLine("Defeat...");
            }
        }
    }
}