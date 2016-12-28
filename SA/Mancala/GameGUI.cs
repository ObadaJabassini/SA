using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Mancala
{
    //GUI
    public partial class Game : IObservable<ResultMessage>
    {
        private List<IObserver<ResultMessage>> _observers = new List<IObserver<ResultMessage>>();

        public Game(IntelligentAgent agent,DifficultyLevel l,int Stonecount)
        {
            this.StonesNum = Stonecount;
            Agent = agent;
            _bins = new IList<int>[]
            {
                 Enumerable.Range(0, BINS_NUM).Select(i => StonesNum).ToList(),
                 Enumerable.Range(0, BINS_NUM).Select(i => StonesNum).ToList()
            };

            _mancals = new[] {0, 0};

            Level = l;

        }
        public IDisposable Subscribe(IObserver<ResultMessage> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
            return null;
        }
        public void NotifyResults(ResultMessage message) => _observers.ForEach(obs => obs.OnNext(message));

        public void Makeachoice()
        {

            Console.WriteLine("Next");
            Console.WriteLine(NextPlayer);
            ResultMessage message = new ResultMessage();
            message.VirtualId = Agent.TakeTurn(this);
            Console.WriteLine("Next2");
            Console.WriteLine(NextPlayer);
            _observers[0].OnNext(message);
        }
    }
}
