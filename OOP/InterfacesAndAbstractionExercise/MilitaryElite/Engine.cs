namespace MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Model;

    public class Engine
    {
        private List<Soldier> solgers;
        private List<Private> privateSolgers;

        public List<Soldier> Solgers => solgers;

        public Engine()
        {
            solgers = new List<Soldier>();
            privateSolgers = new List<Private>();
        }

        public void AddNewLine(string[] line)
        {
            switch (line[0])
            {
                case "Private":
                    AddPrivateSolger(line.Skip(1).ToArray());
                    break;
                case "LieutenantGeneral":
                    AddLieutenantGeneral(line.Skip(1).ToArray());
                    break;
                case "Engineer":
                    AddEngineer(line.Skip(1).ToArray());
                    break;
                case "Commando":
                    AddCommando(line.Skip(1).ToArray());
                    break;
                case "Spy":
                    AddSpy(line.Skip(1).ToArray());
                    break;
            }
        }

        private void AddPrivateSolger(string[] arr)
        {
            var solger = new Private(
                int.Parse(arr[0]),
                arr[1],
                arr[2],
                decimal.Parse(arr[3]));

            solgers.Add(solger);
            privateSolgers.Add(solger);
        }

        private void AddLieutenantGeneral(string[] arr)
        {
            var general = new LieutenantGeneral(
                int.Parse(arr[0]),
                arr[1],
                arr[2],
                decimal.Parse(arr[3]),
                GetPrivate(arr.Skip(4).Select(int.Parse).ToArray()));

            solgers.Add(general);
        }

        private void AddEngineer(string[] arr)
        {
            try
            {
                var engineer = new Engineer(
                    int.Parse(arr[0]),
                    arr[1],
                    arr[2],
                    decimal.Parse(arr[3]),
                    arr[4],
                    Repairs(arr.Skip(5).ToArray()));

                solgers.Add(engineer);
            }
            catch (Exception e)
            {

            }
        }

        private void AddCommando(string[] arr)
        {
            try
            {
                Commando comando = null;
                if (arr.Length > 5)
                {
                    comando = new Commando(
                        int.Parse(arr[0]),
                        arr[1],
                        arr[2],
                        decimal.Parse(arr[3]),
                        arr[4],
                        MakeMissionArray(arr.Skip(5).ToArray()));
                }
                else
                {
                    comando = new Commando(
                        int.Parse(arr[0]),
                        arr[1],
                        arr[2],
                        decimal.Parse(arr[3]),
                        arr[4]);
                }

                solgers.Add(comando);
            }
            catch (Exception e)
            {

            }
        }

        private void AddSpy(string[] arr)
        {
            var solger = new Spy(
                int.Parse(arr[0]),
                arr[1],
                arr[2],
                int.Parse(arr[3]));

            solgers.Add(solger);
        }

        private Private[] GetPrivate(params int[] solgerId)
        {
            List<Private> solger = new List<Private>();
            foreach (var id in solgerId)
            {
                solger.Add(privateSolgers.First(x => x.Id == id));
            }

            return solger.ToArray();
        }

        private Mission[] MakeMissionArray(params string[] missions)
        {
            var currentMisions = new List<Mission>();
            for (int i = 0; i < missions.Length; i += 2)
            {
                try
                {
                    currentMisions.Add(new Mission(missions[i], missions[i + 1]));
                }
                catch (Exception e)
                {

                }
            }

            return currentMisions.ToArray();
        }

        private Repair[] Repairs(params string[] repair)
        {
            var repairs = new List<Repair>();
            for (int i = 0; i < repair.Length; i += 2)
            {
                repairs.Add(new Repair(repair[i], int.Parse(repair[i + 1])));
            }

            return repairs.ToArray();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            solgers.ForEach(x => sb.AppendLine(x.ToString()));

            return sb.ToString().TrimEnd();
        }
    }
}