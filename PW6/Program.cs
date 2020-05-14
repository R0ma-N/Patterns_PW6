using System;

namespace PW6
{
    public abstract class Boss
    {
        protected float confirmedAmount;

        protected Boss nextBoss;

        public Boss(Boss nextBoss, float requestedAmount) => this.nextBoss = nextBoss;

        public void ApproveRequest(float requestedAmount)
        {
            if (requestedAmount <= confirmedAmount)
            {
                Write(requestedAmount);
            }
            else if(nextBoss != null)
            {
                nextBoss.ApproveRequest(requestedAmount);
            }
        }

        abstract protected void Write(float requestedAmount);
    }

    public class BossLvl1 : Boss
    {
        public BossLvl1(Boss nextBoss, float requestedAmount) : base(nextBoss, requestedAmount)
        {
            confirmedAmount = 500;
        }

        protected override void Write(float requestedAmount)
        {
            Console.WriteLine("Boos1: OK. That's your " + requestedAmount);
        }
    }

    class BossLvl2 : Boss
    {
        public BossLvl2(Boss nextBoss, float requestedAmount) : base(nextBoss, requestedAmount)
        {
            confirmedAmount = 1000;
        }

        protected override void Write(float requestedAmount)
        {
            Console.WriteLine("Boos2: OK. That's your " + requestedAmount);
        }
    }

    class BigBoss : Boss
    {
        public BigBoss(Boss nextBoss, float requestedAmount) : base(nextBoss, requestedAmount)
        {
            confirmedAmount = requestedAmount;
        }

        protected override void Write(float requestedAmount)
        {
            Console.WriteLine("Big Boss: OK. That's your " + requestedAmount);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GiveMeMoney(1500);
        }

        private static void GiveMeMoney(float amount)
        {
            BigBoss bigBoss = new BigBoss(null, amount);
            BossLvl2 boss2 = new BossLvl2(bigBoss, amount);
            BossLvl1 boss1 = new BossLvl1(boss2, amount);
            boss1.ApproveRequest(amount);
        }
    }
}
