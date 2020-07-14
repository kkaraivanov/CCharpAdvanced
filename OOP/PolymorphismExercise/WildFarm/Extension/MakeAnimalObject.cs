namespace WildFarm.Extension
{
    using System;
    using Model.Animal;

    public static class MakeAnimalObject
    {
        public static Animal NewAnimalObject(params string[] args)
        {
            switch (args[0])
            {
                case nameof(Cat):
                    return new Cat(args[1], double.Parse(args[2]), args[3], args[4]);
                    break;
                case nameof(Tiger):
                    return new Tiger(args[1], double.Parse(args[2]), args[3], args[4]);
                    break;
                case nameof(Dog):
                    return new Dog(args[1], double.Parse(args[2]), args[3]);
                    break;
                case nameof(Mouse):
                    return new Mouse(args[1], double.Parse(args[2]), args[3]);
                    break;
                case nameof(Owl):
                    return new Owl(args[1], double.Parse(args[2]), double.Parse(args[3]));
                    break;
                case nameof(Hen):
                    return new Hen(args[1], double.Parse(args[2]), double.Parse(args[3]));
                    break;
                default:
                    throw new ArgumentException();
                    break;
            }
        }
    }
}